using System;
using System.Diagnostics;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth.Signing;

namespace Xero.Api.Example.Applications.Public
{
    public class PublicAuthenticator : TokenStoreAuthenticator
    {
        public PublicAuthenticator(string baseUri, string tokenUri, string callBackUrl, ITokenStore store) : base(baseUri, tokenUri, callBackUrl, store)
        {            
        }

        protected override string AuthorizeUser(IToken token)
        {
            if (CallBackUri.Equals("oob"))
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

        protected override string CreateSignature(IToken token, string verb, Uri uri, string verifier)
        {
            return new HmacSha1Signer().CreateSignature(token, uri, verb, verifier);
        }

        protected override IToken RenewToken(IToken sessionToken, IConsumer consumer)
        {
            return GetToken(consumer);
        }
    }   
}