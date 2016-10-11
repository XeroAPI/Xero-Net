using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.ThirdParty.HttpUtility;

namespace Xero.Api.Infrastructure.OAuth
{
    partial class OAuthTokens
    {
        public Task<IToken> GetRequestTokenAsync(IConsumer consumer, string header, CancellationToken cancellation = default(CancellationToken))
        {
            return this.GetTokenAsync(_tokenUri, new Token { ConsumerKey = consumer.ConsumerKey, ConsumerSecret = consumer.ConsumerSecret }, XeroRequestUri, header, cancellation);
        }

        public Task<IToken> GetAccessTokenAsync(IToken token, string header, CancellationToken cancellation = default(CancellationToken))
        {
            return this.GetTokenAsync(_tokenUri, token, XeroAccessTokenUri, header, cancellation);
        }

        public Task<IToken> RenewAccessTokenAsync(IToken token, string header, CancellationToken cancellation = default(CancellationToken))
        {
            return this.GetTokenAsync(_tokenUri, token, XeroAccessTokenUri, header, cancellation);
        }

        public async Task<IToken> GetTokenAsync(string baseUri, IToken consumer, string endPoint, string header, CancellationToken cancellation = default(CancellationToken))
        {
            var req = new HttpClient(baseUri)
            {
                UserAgent = "Xero Api wrapper - " + consumer.ConsumerKey
            };

            if (_clientCertificate != null)
                req.ClientCertificate = _clientCertificate;

            req.AddHeader("Authorization", header);

            var response = await req.PostAsync(endPoint, string.Empty, cancellation: cancellation);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new OAuthException(response.Body);
            }

            var qs = HttpUtility.ParseQueryString(response.Body);
            var expires = qs["oauth_expires_in"];
            var session = qs["oauth_session_handle"];

            var token = new Token(consumer.ConsumerKey, consumer.ConsumerSecret)
            {
                TokenKey = qs["oauth_token"],
                TokenSecret = qs["oauth_token_secret"],
                OrganisationId = qs["xero_org_muid"]
            };

            if (!string.IsNullOrWhiteSpace(expires))
            {
                token.ExpiresAt = DateTime.UtcNow.AddSeconds(int.Parse(expires));
            }

            if (!string.IsNullOrWhiteSpace(session))
            {
                token.Session = session;
                token.SessionExpiresAt = DateTime.UtcNow.AddSeconds(int.Parse(qs["oauth_authorization_expires_in"]));
            }

            return token;
        }
    }
}
