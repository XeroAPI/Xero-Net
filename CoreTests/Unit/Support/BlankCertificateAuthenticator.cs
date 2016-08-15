using System.Net;
using System.Security.Cryptography.X509Certificates;
using Xero.Api.Infrastructure.Interfaces;

namespace CoreTests.Unit.Support
{
    public class BlankCertificateAuthenticator : ICertificateAuthenticator
    {
        public IToken GetToken(IConsumer consumer, IUser user)
        {
            return null;
        }

        public IUser User { get; set; }
        public X509Certificate Certificate { get; private set; }

        public void Authenticate(HttpWebRequest request, IConsumer consumer, IUser user)
        {
        }
    }
}