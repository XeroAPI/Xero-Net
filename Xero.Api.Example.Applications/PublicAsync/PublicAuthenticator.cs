using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xero.Api.Core;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth.Signing;

namespace Xero.Api.Example.Applications.PublicAsync
{
    public class PublicAuthenticator : AsyncTokenStoreAuthenticator
    {
        private readonly string _scope;

        public PublicAuthenticator(string baseUri, string tokenUri, string callBackUrl, IAsyncTokenStore store, string scope = null) 
            : base(baseUri, tokenUri, callBackUrl, store)
        {
            _scope = scope;
        }

        protected override Task<string> AuthorizeUserAsync(IToken token)
        {
            var authorizeUrl = GetAuthorizeUrl(token, _scope);

            Process.Start(authorizeUrl);

            Console.WriteLine("Enter the PIN given on the web page");
            var pin = Console.ReadLine();

            return new Func<string>(() => pin).StartLongRunningAsync();
        }

        protected override string CreateSignature(IToken token, string verb, Uri uri, string verifier,
            bool renewToken = false, string callback = null)
        {
            return new HmacSha1Signer().CreateSignature(token, uri, verb, verifier, callback);
        }

        protected override Task<IToken> RenewTokenAsync(IToken sessionToken, IConsumer consumer)
        {
            return GetTokenAsync(consumer);
        }
    }   
}