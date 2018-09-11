using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using Xero.Api.Common;
using Xero.Api.Infrastructure.Exceptions;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.Model;
using Xero.Api.Infrastructure.RateLimiter;

namespace Xero.Api.Infrastructure.Http
{
    // This makes the calls to the web as text and asks the object mappers to convert to and from objects to text.
    // This knows nothing about the types being passed to and fro. (Except for the constraint in the generic type)
    public class XeroHttpClient
    {
        internal readonly IJsonObjectMapper JsonMapper;
        internal readonly IXmlObjectMapper XmlMapper;
        internal readonly HttpClient Client;

        private XeroHttpClient(IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper)
        {
            JsonMapper = jsonMapper;
            XmlMapper = xmlMapper;
            Parameters = new NameValueCollection();
        }

        public XeroHttpClient(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user,
            IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper)
            : this(baseUri, auth, consumer, user, jsonMapper, xmlMapper, null)
        {
        }

        public XeroHttpClient(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper jsonMapper, IXmlObjectMapper xmlMapper, IRateLimiter rateLimiter)
            : this(jsonMapper, xmlMapper)
        {
            Client = new HttpClient(baseUri, auth, consumer, user, rateLimiter);
        }

        public DateTime? ModifiedSince { get; set; }
        public string Where { get; set; }
        public string Order { get; set; }
        public NameValueCollection Parameters { get; set; }

        public string UserAgent
        {
            get { return Client.UserAgent; }
            set { Client.UserAgent = value; }
        }

        public IEnumerable<TResult> Get<TResult, TResponse>(string endPoint)
            where TResponse : IXeroResponse<TResult>, new()
        {
            Client.ModifiedSince = ModifiedSince;

            return Read<TResult, TResponse>(Client.Get(endPoint, new QueryGenerator(Where, Order, Parameters).UrlEncodedQueryString));
        }

        internal IEnumerable<TResult> Post<TResult, TResponse>(string endpoint, byte[] data, string mimeType)
            where TResponse : IXeroResponse<TResult>, new()
        {
            return Read<TResult, TResponse>(Client.Post(endpoint, data, mimeType, new QueryGenerator(null, null, Parameters).UrlEncodedQueryString));
        }

        public IEnumerable<TResult> Post<TResult, TResponse>(string endPoint, object data)
            where TResponse : IXeroResponse<TResult>, new()
        {
            return Read<TResult, TResponse>(Client.Post(endPoint, XmlMapper.To(data), query: new QueryGenerator(null, null, Parameters).UrlEncodedQueryString));
        }

        public IEnumerable<TResult> Put<TResult, TResponse>(string endPoint, object data)
            where TResponse : IXeroResponse<TResult>, new()
        {
            return Read<TResult, TResponse>(Client.Put(endPoint, XmlMapper.To(data), query: new QueryGenerator(null, null, Parameters).UrlEncodedQueryString));
        }

        public IEnumerable<TResult> Delete<TResult, TResponse>(string endPoint)
            where TResponse : IXeroResponse<TResult>, new()
        {
            return Read<TResult, TResponse>(Client.Delete(endPoint));
        }

        internal Response Get(string endpoint, string mimeType)
        {
            return Client.Get(endpoint, null);
        }

        internal IEnumerable<TResult> Read<TResult, TResponse>(Response response)
            where TResponse : IXeroResponse<TResult>, new()
        {
            // this is the 'happy path'
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonMapper.From<TResponse>(response.Body).Values;
            }

            HandleErrors(response);
            
            return null;
        }

        internal void HandleErrors(Response response)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var data = JsonMapper.From<ApiException>(response.Body);

                if (data.Elements != null && data.Elements.Any())
                {
                    throw new ValidationException(data);
                }

                //CHeck for inline errors
                var jsonObject = JObject.Parse(response.Body);
                var inlineValidationErrors = jsonObject.SelectTokens("$..ValidationErrors..Message").Select(p => new ValidationError { Message = p.ToString() }).ToList();

                if (inlineValidationErrors.Any())
                {
                    data.Elements = new List<DataContractBase> { new DataContractBase {ValidationErrors = inlineValidationErrors } };
                    throw new ValidationException(data);
                }

                throw new BadRequestException(data);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(response.Body);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException(response.Body);
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new XeroApiException(response.StatusCode, response.Body);
            }

            if (response.Headers.ContainsKey("X-Rate-Limit-Problem"))
            {
                var body = response.Body;
                throw new RateExceededException(body, response.Headers["X-Rate-Limit-Problem"]);
            }

            if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                var body = response.Body;

                if (body.Contains("oauth_problem"))
                {
                    throw new RateExceededException(body);
                }

                throw new NotAvailableException(body);
            }

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return;
            }

            
            throw new XeroApiException(response.StatusCode, response.Body);
        }
    }
}
