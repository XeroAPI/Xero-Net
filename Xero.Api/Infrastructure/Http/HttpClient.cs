using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xero.Api.Infrastructure.Http.Bodies;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;
using Xero.Api.Private;

namespace Xero.Api.Infrastructure.Http
{
    internal class HttpClient
    {
        public string BaseUri { get; set; }
        private readonly IAuthenticator _auth = new BlankAuthenticator();
        
        private readonly Dictionary<string, string> _headers;

        public DateTime? ModifiedSince { get; set; }
        public IUser User { get; set; }
        
        private IConsumer Consumer { get; set; }

        public HttpClient(string baseUri)
        {
            BaseUri = baseUri;
            _headers = new Dictionary<string, string>();
        }
        
        public HttpClient(string baseUri, IConsumer consumer, IUser user) : this(baseUri)
        {
            User = user;
            Consumer = consumer;
        }

        public HttpClient(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IRateLimiter rateLimiter)
            : this(baseUri, consumer, user)
        {
            _auth = auth;
        }

        public string UserAgent
        {
            get; set;
        }

        public X509Certificate ClientCertificate
        {
            get;
            set;
        }

        public Response Post(string endpoint, string data, string contentType = "application/xml", string query = null)
        {
            return Post(endpoint, Encoding.UTF8.GetBytes(data), contentType, query);
        }
        
        public Response Post(string endpoint, byte[] data, string contentType = "application/xml", string query = null)
        {
            return Internet.Exec(CreateRequestWithBinaryBody(endpoint, data, "POST", contentType, query));
        }
            
        public Response PostMultipartForm(string endpoint, string contentType, string name, string filename, byte[] payload)
        {
            return Internet.Exec(CreateRequestWithMultipartBody(endpoint, contentType, name, filename, payload));
        }

        public Response Put(string endpoint, string data, string contentType = "application/xml", string query = null)
        {
            return Internet.Exec(CreateRequestWithBinaryBody(endpoint, Encoding.UTF8.GetBytes(data), "PUT", contentType, query));
        }

        public Response Get(string endpoint, string query)
        {
            return Internet.Exec(CreateRequest(endpoint, "GET", query: query));
        }

        public Response GetRaw(string endpoint, string mimeType, string query = null)
        {
            return Internet.Exec(CreateRequest(endpoint, "GET", mimeType, query));
        }

        public Response Delete(string endpoint)
        {
            return Internet.Exec(CreateRequest(endpoint, "DELETE"));
        }

        private WebRequest CreateRequestWithMultipartBody(string endpoint, string contentType, string name, string filename, byte[] payload)
        {
            return (CreateRequest(endpoint, "POST")).Tap(request => 
                MultipartFormData.Write(request, payload, contentType, name, filename));
        }

        private WebRequest CreateRequestWithBinaryBody(string endpoint, byte[] data, string method, string contentType = "application/xml", string query = null)
        {
            return CreateRequest(endpoint, method, query: query).Tap(request => 
                Binary.Write(request, data, contentType));
        }

        private HttpWebRequest CreateRequest(string endPoint, string method, string accept = "application/json", string query = null)
        {
            return (New(method, accept, Url(endPoint, query))).Tap(request => 
            {
                ApplyModifiedSince(request);

                Authenticate(request);

                AddHeaders(request);

                ApplyUserAgent(request);

                ApplyClientCert(request);
            });
        }

        private void ApplyClientCert(HttpWebRequest request)
        {
            if (ClientCertificate != null)
            {
                request.ClientCertificates.Add(ClientCertificate);
            }
        }

        private void ApplyUserAgent(HttpWebRequest request)
        {
            request.UserAgent = !string.IsNullOrWhiteSpace(UserAgent) ? UserAgent : "Xero Api wrapper - " + Consumer.ConsumerKey;
        }

        private UriBuilder Url(string endPoint, string query)
        {
            var uri = new UriBuilder(string.Join(string.Empty, BaseUri, endPoint));

            if (!string.IsNullOrWhiteSpace(query))
            {
                uri.Query = query;
            }

            return uri;
        }

        private static HttpWebRequest New(string method, string accept, UriBuilder uri)
        {
            var request = (HttpWebRequest) WebRequest.Create(uri.Uri);

            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            request.Accept = accept;
            request.Method = method;
            return request;
        }

        private void ApplyModifiedSince(HttpWebRequest request)
        {
            if (ModifiedSince.HasValue)
            {
                request.IfModifiedSince = ModifiedSince.Value;
            }
        }

        private void Authenticate(HttpWebRequest request)
        {
            if (_auth != null)
            {
                _auth.Authenticate(request, Consumer, User);
            }
        }

        private void AddHeaders(WebRequest request)
        {
            foreach (var pair in _headers)
            {
                request.Headers.Add(pair.Key, pair.Value);
            }
        }

        public void AddHeader(string name, string value)
        {
            _headers[name] = value;
        }

        internal void TrimBaseUri()
        {
            var temp = Try.Uri(BaseUri);

            if (temp != null)
            {
                BaseUri = string.Format("{0}://{1}", temp.Scheme, temp.Host);
            }
        }
    }

    internal static class Try
    {
        internal static Uri Uri(string text)
        {
            Uri result;

            System.Uri.TryCreate(text, UriKind.Absolute, out result);

            return result;
        }
    }
}