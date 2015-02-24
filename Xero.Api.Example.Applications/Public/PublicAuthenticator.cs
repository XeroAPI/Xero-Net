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
            var authorizeUrl = GetAuthorizeUrl(token);

            Process.Start(authorizeUrl);

            Console.WriteLine("Enter the PIN given on the web page");

            return Console.ReadLine();
        }

        protected override string CreateSignature(IToken token, string verb, Uri uri, string verifier,
            bool renewToken = false, string callback = null)
        {
            return new HmacSha1Signer().CreateSignature(token, uri, verb, verifier, callback);
        }

        protected override IToken RenewToken(IToken sessionToken, IConsumer consumer)
        {
            return GetToken(consumer);
        }
    }   
}