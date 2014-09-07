using System;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Example.Applications
{
    public abstract class TokenStoreAuthenticator : IAuthenticator
    {
        protected string CallBackUri { get; set; }
        protected string BaseUri { get; set; }
        protected string VerifierUri { get; set; }
        protected ITokenStore Store { get; set; }
        protected OAuthTokens Tokens { get; set; }

        protected TokenStoreAuthenticator(string baseUri, string tokenUri, string authorizeeUri, string callBackUri, ITokenStore store)
        {
            CallBackUri = callBackUri;
            BaseUri = baseUri;
            Store = store;
            Tokens = new OAuthTokens(authorizeeUri, tokenUri);            
        }

        public string GetSignature(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1)
        {
            return GetAuthorization(GetToken(consumer, user), verb, uri.AbsolutePath, uri.Query, null, CallBackUri);
        }

        public IToken GetToken(IConsumer consumer, IUser user)
        {
            IToken token;

            if (HasStore)
            {
                token = Store.Find(user.Name);

                if (token == null)
                {
                    token = GetToken(consumer);
                    token.UserId = user.Name;

                    Store.Add(token);
                }
                else if (token.HasExpired)
                {
                    IToken renewedToken = RenewToken(token, consumer);
                    renewedToken.UserId = user.Name;
                    token = renewedToken;
                    Store.Add(token);
                }
            }
            else
            {
                token = GetToken(consumer);
            }

            return token;
        }

        public bool HasStore
        {
            get { return Store != null; }
        }

        public IUser User { get; set; }

        protected abstract string AuthorizeUser(IToken oauthToken);
        protected abstract string CreateSignature(IToken token, string verb, Uri uri, string verifier, string callback, bool renewToken = false);
        protected abstract IToken GetToken(IConsumer consumer);
        protected abstract IToken RenewToken(IToken sessionToken, IConsumer consumer);

        protected string GetAuthorization(IToken token, string verb, string endpoint, string query = null, string verifier = null, string callback = null, bool renewToken = false)
        {
            var uri = new UriBuilder(BaseUri)
            {
                Path = endpoint
            };

            if (!string.IsNullOrWhiteSpace(query))
            {
                uri.Query = query.TrimStart('?');
            }

            return CreateSignature(token, verb, uri.Uri, verifier, callback, renewToken);
        }
    }
}
