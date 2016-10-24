using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;

namespace Xero.Api.Infrastructure.Http
{
    /// <summary>
    /// Adds async support to the HttpClient
    /// </summary>
    partial class HttpClient
    {
        private readonly IAsyncAuthenticator _authAsync;
        private readonly IAsyncRateLimiter _rateLimiterAsync;
        private System.Net.Http.HttpClient asyncClient;

        public HttpClient(string baseUri, IAsyncAuthenticator auth, IConsumer consumer, IUser user)
            : this(baseUri, consumer, user)
        {
            _isAsyncAuth = true;
            _authAsync = auth;
        }

        public HttpClient(string baseUri, IAsyncAuthenticator auth, IConsumer consumer, IUser user, IAsyncRateLimiter rateLimiter)
            : this(baseUri, auth, consumer, user)
        {
            _rateLimiterAsync = rateLimiter;
        }

        public HttpClient(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user, IAsyncRateLimiter rateLimiter)
            : this(baseUri, auth, consumer, user)
        {
            _rateLimiterAsync = rateLimiter;
        }

        public HttpClient(string baseUri, IAsyncAuthenticator auth, IConsumer consumer, IUser user, IRateLimiter rateLimiter)
            : this(baseUri, auth, consumer, user)
        {
            _rateLimiter = rateLimiter;
        }

        public System.Net.Http.HttpClient AsyncClient
        {
            get
            {
                if (this.asyncClient == null)
                {
                    // TODO: Verify client is initialized with correct parameters
                    var handler = new HttpClientHandler
                    {
                        CookieContainer = new CookieContainer(),
                        UseCookies = true,
                        AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                        ClientCertificateOptions = ClientCertificateOption.Automatic,
                    };

                    this.asyncClient = new System.Net.Http.HttpClient(handler)
                    {
                        Timeout = TimeSpan.FromMilliseconds(defaultTimeout)
                    };
                }

                return this.asyncClient;
            }
        }

        public async Task<Response> PutAsync(string endpoint, string data, string contentType = "application/xml", string query = null, CancellationToken cancellation = default(CancellationToken))
        {
            var requestMessage = await this.CreateRequestAsync(endpoint, HttpMethod.Put, new StringContent(data), contentType: contentType, query: query, cancellation: cancellation);
            return await this.WriteToServerAsync(requestMessage, cancellation);
        }

        public async Task<Response> GetAsync(string endpoint, string query, CancellationToken cancellation = default(CancellationToken))
        {
            var requestMessage = await this.CreateRequestAsync(endpoint, HttpMethod.Get, null, query: query, cancellation: cancellation);
            return await this.WriteToServerAsync(requestMessage, cancellation);
        }

        public async Task<Response> GetRawAsync(string endpoint, string mimeType, string query = null, CancellationToken cancellation = default(CancellationToken))
        {
            var requestMessage = await this.CreateRequestAsync(endpoint, HttpMethod.Get, null, query: query, accept: mimeType);
            return await this.WriteToServerAsync(requestMessage, cancellation);
        }

        public async Task<Response> DeleteAsync(string endpoint, CancellationToken cancellation = default(CancellationToken))
        {
            var requestMessage = await this.CreateRequestAsync(endpoint, HttpMethod.Delete, null, cancellation: cancellation);
            return await this.WriteToServerAsync(requestMessage, cancellation);
        }

        public async Task<Response> PostAsync(string endpoint, string data, string contentType = "application/xml", string query = null, CancellationToken cancellation = default(CancellationToken))
        {
            var requestMessage = await this.CreateRequestAsync(endpoint, HttpMethod.Post, new StringContent(data), contentType, query, cancellation: cancellation);
            return await this.WriteToServerAsync(requestMessage, cancellation);
        }

        public async Task<Response> PostAsync(string endpoint, byte[] data, string contentType = "application/xml", string query = null, CancellationToken cancellation = default(CancellationToken))
        {
            var requestMessage = await this.CreateRequestAsync(endpoint, HttpMethod.Post, new ByteArrayContent(data), contentType, query, cancellation: cancellation);
            return await this.WriteToServerAsync(requestMessage, cancellation);
        }

        public Task<Response> PostMultipartFormAsync(string endpoint, string contentType, string name, string filename, byte[] payload, CancellationToken cancellation = default(CancellationToken))
        {
            // todo:
            ////return WriteToServerWithMultipartAsync(endpoint, contentType, name, filename, payload, cancellation);
            throw new NotImplementedException();
        }

        private async Task<Response> WriteToServerAsync(HttpRequestMessage requestMessage, CancellationToken cancellation)
        {
            if (_rateLimiterAsync != null)
            {
                await _rateLimiterAsync.WaitUntilLimitAsync(cancellation);
            }
            else if (_rateLimiter != null)
            {
                await Task.Factory.StartNew(_rateLimiter.WaitUntilLimit, TaskCreationOptions.LongRunning);
            }

            var response = await this.AsyncClient.SendAsync(requestMessage);
            return await Response.CreateResponseAsync(response);
        }

        private async Task<HttpRequestMessage> CreateRequestAsync(string endpoint, HttpMethod method, HttpContent content, string contentType = null, string query = null, string accept = "application/json", CancellationToken cancellation = default(CancellationToken))
        {
            var uri = new UriBuilder(_baseUri)
            {
                Path = endpoint,
            };

            if (!string.IsNullOrWhiteSpace(query))
            {
                uri.Query = query;
            }
            
            var request = new HttpRequestMessage(method, uri.Uri)
            {
                Content = content
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));
            if (ModifiedSince.HasValue)
            {
                request.Headers.IfModifiedSince = ModifiedSince.Value;
            }

            await this.SetHeadersAsync(request, method.ToString(), contentType, cancellation);
            return request;
        }

        private async Task SetHeadersAsync(HttpRequestMessage message, string method, string contentType, CancellationToken cancellation)
        {
            var content = message.Content;
            if (content != null && contentType != null)
            {
                content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            }

            if (this._authAsync != null || this._auth != null)
            {
                var oauthSignature = this._authAsync != null
                    ? await this._authAsync.GetSignatureAsync(Consumer, User, message.RequestUri, method, Consumer, cancellation) 
                    : this._auth.GetSignature(Consumer, User, message.RequestUri, method, Consumer);

                AddHeader("Authorization", oauthSignature);                
            }

            foreach (var pair in _headers)
            {
                message.Headers.Add(pair.Key, pair.Value);
            }
        }
    }
}
