using System.Net;
using Xero.Api.Infrastructure.Interfaces;

namespace CoreTests.Unit.Support
{
    public class BlankAuthenticator : IAuthenticator
    {
        public void Authenticate(HttpWebRequest request, IConsumer consumer, IUser user)
        {
        }
    }
}