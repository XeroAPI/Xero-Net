using System.Security.Cryptography.X509Certificates;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface ICertificateAuthenticator : IAuthenticator
    {
        X509Certificate Certificate { get; }
    }
}