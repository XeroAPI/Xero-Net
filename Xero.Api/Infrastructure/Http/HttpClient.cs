using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Infrastructure.Http
{
    // This has enough functionality to get the call the API.
    // Content and accept types are defaulted and it is always ask for the response to be compressed.
    // Json for GET and XML for PUT and POST
    // It uses IAuthenticator or ICertificateAuthenticator to do the signing
    internal class HttpClient
    {
        private readonly string _baseUri;
        private readonly IAuthenticator _auth;
        private readonly ICertificateAuthenticator _certAuth;
        private readonly Dictionary<string, string> _headers;

        public DateTime? ModifiedSince { get; set; }
        public IUser User { get; set; }
        
        private IConsumer Consumer { get; set; }

        public HttpClient(string baseUri)
        {
            _baseUri = baseUri;
            _headers = new Dictionary<string, string>();
        }
        
        public HttpClient(string baseUri, IConsumer consumer, IUser user) : this(baseUri)
        {
            User = user;
            Consumer = consumer;
        }

        public HttpClient(string baseUri, IAuthenticator auth, IConsumer consumer, IUser user)
            : this(baseUri, consumer, user)
        {
            _auth = auth;
        }

        public HttpClient(string baseUri, ICertificateAuthenticator auth, IConsumer consumer, IUser user)
            : this(baseUri, consumer, user)
        {
            _certAuth = auth;
            _auth = auth;
        }

        public string UserAgent
        {
            get; set;
        }

        public Response Post(string endpoint, string data, string contentType = "application/xml", string query = null)
        {
            return Post(endpoint, Encoding.UTF8.GetBytes(data), contentType, query);
        }

        public Response Post(string endpoint, byte[] data, string contentType = "application/xml", string query = null)
        {
            try
            {
                return WriteToServer(endpoint, data, "POST", contentType, query);
            }
            catch (WebException we)
            {
                return new Response((HttpWebResponse)we.Response);
            }
        }

        public Response Put(string endpoint, string data, string contentType = "application/xml", string query = null)
        {
            try
            {
                return WriteToServer(endpoint, Encoding.UTF8.GetBytes(data), "PUT", contentType, query);
            }
            catch (WebException we)
            {
                return new Response((HttpWebResponse)we.Response);
            }
        }

        public Response Get(string endpoint, string query)
        {
            try
            {
                var request = CreateRequest(endpoint, "GET", query: query);
                return new Response((HttpWebResponse)request.GetResponse());
            }
            catch (WebException we)
            {
                return new Response((HttpWebResponse)we.Response);
            }
        }

        public Response GetRaw(string endpoint, string mimeType, string query = null)
        {
            try
            {
                var request = CreateRequest(endpoint, "GET", mimeType, query);
                return new Response((HttpWebResponse)request.GetResponse());
            }
            catch (WebException we)
            {
                return new Response((HttpWebResponse)we.Response);
            }
        }

        public Response Delete(string endpoint)
        {
            var request = CreateRequest(endpoint, "DELETE");
            return new Response((HttpWebResponse)request.GetResponse());
        }

        private HttpWebRequest CreateRequest(string endPoint, string method, string accept = "application/json", string query = null)
        {
            var uri = new UriBuilder(_baseUri)
            {
                Path = endPoint,
            };

            if (!string.IsNullOrWhiteSpace(query))
            {
                uri.Query = query;
            }

            var request = (HttpWebRequest)WebRequest.Create(uri.Uri);

            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            
            request.Accept = accept;
            request.Method = method;

            if (ModifiedSince.HasValue)
            {
                request.IfModifiedSince = ModifiedSince.Value;
            }

            if (_auth != null)
            {
                var oauthSignature = _auth.GetSignature(Consumer, User, request.RequestUri, method, Consumer);

                AddHeader("Authorization", oauthSignature);                
            }
            
            AddHeaders(request);

            request.UserAgent = !string.IsNullOrWhiteSpace(UserAgent) ? UserAgent : "Xero Api wrapper - " + Consumer.ConsumerKey;
            
            if (_certAuth != null)
            {
                request.ClientCertificates.Add(_certAuth.Certificate);
            }

            return request;
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

        private static void WriteData(byte[] bytes, WebRequest request, string contentType)
        {
            request.ContentLength = bytes.Length;
            request.ContentType = contentType;

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(bytes, 0, bytes.Length);
                dataStream.Close();
            }
        }

        private Response WriteToServer(string endpoint, byte[] data, string method, string contentType = "application/xml", string query = null)
        {
            var request = CreateRequest(endpoint, method, query: query);
            WriteData(data, request, contentType);
            return new Response((HttpWebResponse)request.GetResponse());
        }        
    }
}