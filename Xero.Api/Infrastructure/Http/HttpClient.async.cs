using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Infrastructure.RateLimiter;

namespace Xero.Api.Infrastructure.Http
{
    /// <summary>
    /// Adds async support to the HttpClient
    /// </summary>
    partial class HttpClient
    {
        private System.Net.Http.HttpClient asyncClient;

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
            var requestMessage = this.CreateRequest(endpoint, HttpMethod.Put, new StringContent(data), contentType: contentType, query: query);
            return await this.WriteToServerAsync(requestMessage, cancellation);
        }

        public async Task<Response> GetAsync(string endpoint, string query, CancellationToken cancellation = default(CancellationToken))
        {
            var requestMessage = this.CreateRequest(endpoint, HttpMethod.Get, new StringContent(string.Empty), query: query);
            return await this.WriteToServerAsync(requestMessage, cancellation);
        }

        public async Task<Response> DeleteAsync(string endpoint, CancellationToken cancellation = default(CancellationToken))
        {
            var requestMessage = this.CreateRequest(endpoint, HttpMethod.Delete, new StringContent(string.Empty));
            return await this.WriteToServerAsync(requestMessage, cancellation);
        }

        public async Task<Response> PostAsync(string endpoint, string data, string contentType = "application/xml", string query = null, CancellationToken cancellation = default(CancellationToken))
        {
            var requestMessage = this.CreateRequest(endpoint, HttpMethod.Post, new StringContent(data), contentType, query);
            return await this.WriteToServerAsync(requestMessage, cancellation);
        }

        public async Task<Response> PostAsync(string endpoint, byte[] data, string contentType = "application/xml", string query = null, CancellationToken cancellation = default(CancellationToken))
        {
            var requestMessage = this.CreateRequest(endpoint, HttpMethod.Post, new ByteArrayContent(data), contentType, query);
            return await this.WriteToServerAsync(requestMessage, cancellation);
        }

        private async Task<Response> WriteToServerAsync(HttpRequestMessage requestMessage, CancellationToken cancellation)
        {
            var asyncRateLimiter = _rateLimiter as IAsyncRateLimiter;
            if (asyncRateLimiter != null)
            {
                await asyncRateLimiter.WaitUntilLimitAsync(cancellation);
            }
            else if (_rateLimiter != null)
            {
                // Fall back to synchronous rate limit if async not implemented.
                await Task.Factory.StartNew(_rateLimiter.WaitUntilLimit, TaskCreationOptions.LongRunning);
            }

            var response = await this.AsyncClient.SendAsync(requestMessage);
            return await Response.CreateResponseAsync(response);
        }

        private HttpRequestMessage CreateRequest(string endpoint, HttpMethod method, HttpContent content, string contentType = null, string query = null, string accept = "application/json")
        {
            var uri = new UriBuilder(_baseUri)
            {
                Path = endpoint,
            };

            if (!string.IsNullOrWhiteSpace(query))
            {
                uri.Query = query;
            }

            var url = uri.Uri;
            var message = new HttpRequestMessage(method, url)
            {
                Content = content
            };

            this.SetHeaders(message, method.ToString(), contentType);
            return message;
        }

        private void SetHeaders(HttpRequestMessage message, string method, string contentType = null)
        {
            var content = message.Content;
            if (contentType != null)
            {
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
            }

            foreach (var pair in _headers)
            {
                message.Headers.Add(pair.Key, pair.Value);
            }

            // TODO: Verify local/utc time conversion is correct
            content.Headers.LastModified = this.ModifiedSince;

            if (this._auth != null)
            {
                var oauthSignature = this._auth.GetSignature(Consumer, User, message.RequestUri, method, Consumer);

                AddHeader("Authorization", oauthSignature);
            }
        }
    }
}
