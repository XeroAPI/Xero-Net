using System.Net;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAuthenticator
    {
        string GetAuthenticationString(HttpWebRequest request, IConsumer consumer, IUser user);
    }
}
