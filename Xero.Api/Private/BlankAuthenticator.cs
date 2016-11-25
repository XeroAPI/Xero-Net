using System.Net;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Private
{
    public class BlankAuthenticator : IAuthenticator
    {
        public void Authenticate(HttpWebRequest request, IConsumer consumer, IUser user)
        {
        }
    }
}
