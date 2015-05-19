using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Infrastructure.OAuth.Signing;

namespace Xero.Api.Example.Applications.Private
{
    public class PrivateAuthenticator : IAuthenticator
    {
        private readonly X509Certificate2 _certificate;

        public PrivateAuthenticator(SigningCertificate cert)
        {
            _certificate = new X509Certificate2();
            TryImport(cert);
        }

        private void TryImport(SigningCertificate certificatePath)
        {
            MustExist(certificatePath.Path);

            _certificate.Import(certificatePath.Path, certificatePath.Password, X509KeyStorageFlags.DefaultKeySet);
        }

        private static void MustExist(string certificatePath)
        {
            if (IsMissing(certificatePath))
                throw new FileNotFoundException(
                    "Unable to continue because the certificate file <" + certificatePath + "> does not exist.");
        }

        private static bool IsMissing(string certificatePath)
        {
            return false == File.Exists(certificatePath);
        }

        public PrivateAuthenticator(X509Certificate2 certificate)
        {
            _certificate = certificate;
        }

        public string GetSignature(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1)
        {
            var token = new Token
            {
                ConsumerKey = consumer.ConsumerKey,
                ConsumerSecret = consumer.ConsumerSecret,
                TokenKey = consumer.ConsumerKey
            };

            return new RsaSha1Signer().CreateSignature(_certificate, token, uri, verb);
        }

        public X509Certificate Certificate { get { return _certificate; } }

        public IToken GetToken(IConsumer consumer, IUser user)
        {
            return null;
        }

        public IUser User { get; set; }
    }
}