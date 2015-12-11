using System;
using System.Security.Cryptography.X509Certificates;
using Xero.Api.Example.Applications.Public;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth.Signing;

namespace Xero.Api.Example.Applications.Partner
{
    public class PartnerMvcAuthenticator : PublicMvcAuthenticator, ICertificateAuthenticator
    {       
        private readonly X509Certificate2 _certificate;
        private readonly X509Certificate2 _signingCertificate;

        private PartnerMvcAuthenticator(string baseUri, string authorizeUri, string callBackUri,
            ITokenStore store, IConsumer consumer, ITokenStore requestTokenStore)
            : base(baseUri, authorizeUri, callBackUri, store, consumer, requestTokenStore)
        {            
        }

        public PartnerMvcAuthenticator(string baseUri, string authorizeUri, string callBackUri, 
            ITokenStore store, string signingCertificatePath, string certificatePath, string password,
            IConsumer consumer, ITokenStore requestTokenStore)
            : this(baseUri, authorizeUri, callBackUri, store, signingCertificatePath, certificatePath, password, consumer, requestTokenStore, "")
        {
        }

        public PartnerMvcAuthenticator(string baseUri, string authorizeUri, string callBackUri, 
            ITokenStore store, string signingCertificatePath, string certificatePath, string entrustPassword,
            IConsumer consumer, ITokenStore requestTokenStore, string signingCertPassword)
            : this(baseUri, authorizeUri, callBackUri, store, consumer, requestTokenStore)
        {
            _signingCertificate = new X509Certificate2(signingCertificatePath, signingCertPassword, X509KeyStorageFlags.MachineKeySet);
            _certificate = new X509Certificate2(certificatePath, entrustPassword);            
        }

        public PartnerMvcAuthenticator(string baseUri, string authorizeUri, string callBackUri, 
            ITokenStore store, X509Certificate2 signingCertificate, X509Certificate2 certificate,
            IConsumer consumer, ITokenStore requestTokenStore)
            : this(baseUri, authorizeUri, callBackUri, store, consumer, requestTokenStore)
        {
            _signingCertificate = signingCertificate;
            _certificate = certificate;
        }

        public X509Certificate Certificate { get { return _certificate; } }

        protected override string CreateSignature(IToken token, string verb, Uri uri,
            string verifier, bool renewToken = false, string callback = null)
        {
            return new RsaSha1Signer().CreateSignature(_signingCertificate, token, uri, verb, verifier, renewToken, callback);
        }

        protected override X509Certificate2 GetClientCertificate()
        {
            return _certificate;
        }

        protected override IToken RenewToken(IToken sessionToken, IConsumer consumer)
        {
            var authHeader = GetAuthorization(sessionToken, "POST", Tokens.AccessUri, null, null, true);

            return Tokens.GetAccessToken(sessionToken, authHeader);
        }
    }
}
