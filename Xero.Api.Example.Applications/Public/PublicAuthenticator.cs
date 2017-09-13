using System;
using System.Diagnostics;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth.Signing;

namespace Xero.Api.Example.Applications.Public
{
    public class PublicAuthenticator : TokenStoreAuthenticator
    {
        private readonly string _scope;
        private readonly bool _redirectOnError;

        public PublicAuthenticator(string baseUri, string tokenUri, string callBackUrl, ITokenStore store, string scope = null, bool redirectOnError = false)
            : base(baseUri, tokenUri, callBackUrl, store)
        {
            _scope = scope;
            _redirectOnError = redirectOnError;
        }

        protected override string AuthorizeUser(IToken token)
        {
            var authorizeUrl = GetAuthorizeUrl(token, _scope, _redirectOnError);

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