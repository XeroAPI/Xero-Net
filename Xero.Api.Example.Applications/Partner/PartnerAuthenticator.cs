using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth.Signing;

namespace Xero.Api.Example.Applications.Partner
{
    public class PartnerAuthenticator : TokenStoreAuthenticator, ICertificateAuthenticator
    {       
        private readonly X509Certificate2 _certificate;
        private readonly X509Certificate2 _signingCertificate;

        private PartnerAuthenticator(string baseUri, string authorizeUri, string callBackUri, ITokenStore store)
            : base(baseUri, authorizeUri, callBackUri, store)
        {            
        }

        public PartnerAuthenticator(string baseUri, string authorizeUri, string callBackUri, ITokenStore store, string signingCertificatePath, string certificatePath, string password)
            : this(baseUri, authorizeUri, callBackUri, store)
        {
            _signingCertificate = new X509Certificate2(signingCertificatePath);
            _certificate = new X509Certificate2(certificatePath, password);            
        }

        public PartnerAuthenticator(string baseUri, string authorizeUri, string callBackUri, ITokenStore store, X509Certificate2 signingCertificate, X509Certificate2 certificate)
            : this(baseUri, authorizeUri, callBackUri, store)
        {
            _signingCertificate = signingCertificate;
            _certificate = certificate;
        }

        public X509Certificate Certificate { get { return _certificate; } }

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

        protected override string CreateSignature(IToken token, string verb, Uri uri,
            string verifier, bool renewToken = false, string callback = null)
        {
            return new RsaSha1Signer().CreateSignature(_signingCertificate, token, uri, verb, verifier, renewToken);
        }

        protected override IToken RenewToken(IToken sessionToken, IConsumer consumer)
        {
            var authHeader = GetAuthorization(sessionToken, "POST", Tokens.AccessUri, null, null, true);

            return Tokens.GetAccessToken(sessionToken, authHeader);
        }

        protected override X509Certificate2 GetClientCertificate()
        {
            return _certificate;
        }
    }
}
