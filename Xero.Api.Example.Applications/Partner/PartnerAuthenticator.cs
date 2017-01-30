using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth.Signing;

namespace Xero.Api.Example.Applications.Partner
{
    public class PartnerAuthenticator : TokenStoreAuthenticator
    {       
        private readonly X509Certificate2 _signingCertificate;

        private PartnerAuthenticator(string baseUri, string authorizeUri, string callBackUri, ITokenStore store)
            : base(baseUri, authorizeUri, callBackUri, store)
        {            
        }

        public PartnerAuthenticator(string baseUri, string authorizeUri, string callBackUri, ITokenStore store, string signingCertificatePath)
            : this(baseUri, authorizeUri, callBackUri, store, signingCertificatePath, "")
        {
        }

        public PartnerAuthenticator(string baseUri, string authorizeUri, string callBackUri, ITokenStore store, string signingCertificatePath, string signingCertPassword)
            : this(baseUri, authorizeUri, callBackUri, store)
        {
            _signingCertificate = new X509Certificate2(signingCertificatePath, signingCertPassword, X509KeyStorageFlags.MachineKeySet);
        }

        public PartnerAuthenticator(string baseUri, string authorizeUri, string callBackUri, ITokenStore store, X509Certificate2 signingCertificate)
            : this(baseUri, authorizeUri, callBackUri, store)
        {
            _signingCertificate = signingCertificate;
        }

        protected override string AuthorizeUser(IToken token)
        {
            var authorizeUrl = GetAuthorizeUrl(token);

            Process.Start(authorizeUrl);

            Console.WriteLine("Enter the PIN given on the web page");

            return Console.ReadLine();
        }

        protected override string CreateSignature(IToken token, string verb, Uri uri,
            string verifier, bool renewToken = false, string callback = null)
        {
            return new RsaSha1Signer().CreateSignature(_signingCertificate, token, uri, verb, verifier, renewToken, callback);
        }

        protected override IToken RenewToken(IToken sessionToken, IConsumer consumer)
        {
            var authHeader = GetAuthorization(sessionToken, "POST", Tokens.AccessUri, null, null, true);

            return Tokens.GetAccessToken(sessionToken, authHeader);
        }
    }
}
