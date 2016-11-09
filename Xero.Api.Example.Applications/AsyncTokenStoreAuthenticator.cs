using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Example.Applications
{
    public abstract class AsyncTokenStoreAuthenticator : IAsyncAuthenticator
    {
        private readonly string _tokenUri;
        protected string CallBackUri { get; set; }
        protected string BaseUri { get; set; }
        protected string VerifierUri { get; set; }
        protected IAsyncTokenStore Store { get; set; }

        private OAuthTokens _tokens;

        protected OAuthTokens Tokens 
        {
            get 
            {
                if (_tokens == null)
                {
                    _tokens = new OAuthTokens(_tokenUri, BaseUri, GetClientCertificate());      
                }
                return _tokens;
            } 
        }

        protected AsyncTokenStoreAuthenticator(string baseUri, string tokenUri, string callBackUri, IAsyncTokenStore store)
        {
            _tokenUri = tokenUri;
            CallBackUri = callBackUri;
            BaseUri = baseUri;
            Store = store;                      
        }

        protected virtual X509Certificate2 GetClientCertificate()
        {
            return null;            
        }

        public Task<string> GetSignatureAsync(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1)
        {
            return this.GetSignatureAsync(consumer, user, uri, verb, consumer1, default(CancellationToken));
        }

        public async Task<string> GetSignatureAsync(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1, CancellationToken cancellation)
        {
            return GetAuthorization(await GetTokenAsync(consumer, user, cancellation), verb, uri.AbsolutePath, uri.Query);
        }

        public Task<IToken> GetTokenAsync(IConsumer consumer, IUser user)
        {
            return GetTokenAsync(consumer, user, default(CancellationToken));
        }

        public async Task<IToken> GetTokenAsync(IConsumer consumer, IUser user, CancellationToken cancellation)
        {
            if (!HasStore)
                return await GetTokenAsync(consumer, cancellation);

            var token = await Store.FindAsync(user.Name);

            if (token == null)
            {
                token = await GetTokenAsync(consumer, cancellation);
                token.UserId = user.Name;

                await Store.AddAsync(token);

                return token;
            }

            if (!token.HasExpired)
                return token;
            
            var newToken = await RenewTokenAsync(token, consumer);
            newToken.UserId = user.Name;

            await Store.DeleteAsync(token);
            await Store.AddAsync(newToken);

            return newToken;
        }

        public bool HasStore
        {
            get { return Store != null; }
        }

        public IUser User { get; set; }

        protected abstract Task<string> AuthorizeUserAsync(IToken oauthToken);
        protected abstract string CreateSignature(IToken token, string verb, Uri uri, string verifier,
            bool renewToken = false, string callback = null);

        protected abstract Task<IToken> RenewTokenAsync(IToken sessionToken, IConsumer consumer);

        protected virtual async Task<IToken> GetTokenAsync(IConsumer consumer, CancellationToken cancellation = default(CancellationToken))
        {
            var requestToken = await GetRequestTokenAsync(consumer);
   
            var verifier = await AuthorizeUserAsync(requestToken);

            return await Tokens.GetAccessTokenAsync(requestToken,
                GetAuthorization(requestToken, "POST", Tokens.AccessUri, null, verifier));
        }

        protected string GetAuthorizeUrl(IToken token, string scope = null)
        {
            return new UriBuilder(Tokens.AuthorizeUri)
            {
                Query = "oauth_token=" + token.TokenKey + "&scope=" + scope
            }.Uri.ToString();
        }

        protected async Task<IToken> GetRequestTokenAsync(IConsumer consumer)
        {
            var token = new Token
            {
                ConsumerKey = consumer.ConsumerKey,
                ConsumerSecret = consumer.ConsumerSecret
            };
            
            var requestTokenOAuthHeader = GetAuthorization(token, "POST", Tokens.RequestUri, callback: CallBackUri);

            return await Tokens.GetRequestTokenAsync(consumer, requestTokenOAuthHeader);
        }

        protected string GetAuthorization(IToken token, string verb, string endpoint, string query = null,
            string verifier = null, bool renewToken = false, string callback = null)
        {
            var uri = new UriBuilder(BaseUri)
            {
                Path = endpoint
            };

            if (!string.IsNullOrWhiteSpace(query))
            {
                uri.Query = query.TrimStart('?');
            }

            return CreateSignature(token, verb, uri.Uri, verifier, renewToken, callback);
        }
    }
}
