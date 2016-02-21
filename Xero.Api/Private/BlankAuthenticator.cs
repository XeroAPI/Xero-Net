using System.Net;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Private
{
    internal class BlankAuthenticator : IAuthenticator
    {
        public string GetAuthenticationString(HttpWebRequest request, IConsumer consumer, IUser user)
        {
            return null;
        }
    }
}