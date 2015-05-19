using System;
using System.Net;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAuthenticator
    {
        [Obsolete("Use Authenticate instead")]
        string GetSignature(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1);

        [Obsolete("Use Authenticate instead")]
        IToken GetToken(IConsumer consumer, IUser user);

        [Obsolete("Use Authenticate instead")]
        IUser User { get; set; }

        void Authenticate(HttpWebRequest request);
    }
}
