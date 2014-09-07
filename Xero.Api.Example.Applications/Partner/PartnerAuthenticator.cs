using System;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Infrastructure.OAuth.Signing;

namespace Xero.Api.Example.Applications.Partner
{
    public class PartnerAuthenticator : TokenStoreAuthenticator, ICertificateAuthenticator
    {       
        private readonly X509Certificate2 _certificate;
        private readonly X509Certificate2 _signingCertificate;

        private PartnerAuthenticator(string baseUri, string tokenUri, string authorizeUri, string callBackUri, ITokenStore store)
            : base(baseUri, tokenUri, authorizeUri, callBackUri, store)
        {            
        }

        public PartnerAuthenticator(string baseUri, string tokenUri, string authorizeUri, string callBackUri, ITokenStore store, string signingCertificatePath, string certificatePath, string password)
            : this(baseUri, tokenUri, authorizeUri, callBackUri, store)
        {
            _signingCertificate = new X509Certificate2(signingCertificatePath, password);
            _certificate = new X509Certificate2(certificatePath, password);
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidationCallback;
        }

        public bool RemoteCertificateValidationCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public PartnerAuthenticator(string baseUri, string tokenUri, string authorizeUri, string callBackUri, ITokenStore store, X509Certificate2 signingCertificate, X509Certificate2 certificate)
            : this(baseUri, tokenUri, authorizeUri, callBackUri, store)
        {
            _signingCertificate = signingCertificate;
            _certificate = certificate;
        }

        public X509Certificate Certificate { get { return _certificate; } }

        protected override string AuthorizeUser(IToken token)
        {
            if (CallBackUri != "oob")
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
            return new RsaSha1Signer().CreateSignature(_signingCertificate, token, uri, verb, verifier, callback, renewToken);
        }

        protected override IToken GetToken(IConsumer consumer)
        {
            var oauthToken = Tokens.GetRequestToken(consumer, GetAuthorization(new Token
            {
                ConsumerKey = consumer.ConsumerKey,
                ConsumerSecret = consumer.ConsumerSecret
            }, "POST", Tokens.RequestUri, null, null, CallBackUri), this);

            var verifier = AuthorizeUser(oauthToken);

            return Tokens.GetAccessToken(oauthToken,
                GetAuthorization(oauthToken, "POST", Tokens.AccessUri, null, verifier, CallBackUri), this);
        }

        protected override IToken RenewToken(IToken sessionToken, IConsumer consumer)
        {
            return Tokens.RenewAccessToken(sessionToken,
                GetAuthorization(sessionToken, "POST", Tokens.AccessUri, null, null, CallBackUri, true), this);
        }
    }
}
