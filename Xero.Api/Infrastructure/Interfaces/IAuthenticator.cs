using System.Net;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAuthenticator
    {
        void Authenticate(HttpWebRequest request);
    }
}
