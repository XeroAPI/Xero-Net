using System;
using System.Diagnostics;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Infrastructure.OAuth.Signing;
using Xero.Api.Infrastructure.ThirdParty.Dust;

namespace Xero.Api.Example.Applications.Public
{
    public class PublicAuthenticator : TokenStoreAuthenticator
    {
        public PublicAuthenticator(string baseUri, string tokenUri, string authorizeUri, string callBackUrl, ITokenStore store) 
            : base(baseUri, tokenUri, authorizeUri, callBackUrl, store)
        {            
        }

        protected override string AuthorizeUser(IToken token)
        {
            if (!CallBackUri.Equals("oob"))
            {
                Process.Start(new UriBuilder(Tokens.AuthorizeUri)
                {                     
                    Query = "oauth_token=" + token.TokenKey
                }.Uri.ToString());

                Console.WriteLine("Enter the PIN given on the web page");
                return Console.ReadLine();
            }

            return string.Empty;
        }

        protected override string CreateSignature(IToken token, string verb, Uri uri, string verifier, string callback, bool renewToken = false)
        {
            return new HmacSha1Signer().CreateSignature(token, uri, verb, verifier, callback);
        }

        protected override IToken GetToken(IConsumer consumer)
        {
            var oauthToken = Tokens.GetRequestToken(consumer, GetAuthorization(new Token
            {
                ConsumerKey = consumer.ConsumerKey,
                ConsumerSecret = consumer.ConsumerSecret
            }, "POST", Tokens.RequestUri, null, null, CallBackUri));

            var verifier = AuthorizeUser(oauthToken);

            return Tokens.GetAccessToken(oauthToken,
                GetAuthorization(oauthToken, "POST", Tokens.AccessUri, null, verifier, CallBackUri));
        }

        protected override IToken RenewToken(IToken sessionToken, IConsumer consumer)
        {
            return sessionToken;
        }
    }   
}