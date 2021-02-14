using System;
using System.Collections.Generic;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAuthenticator
    {
        string GetSignature(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1);
        IToken GetToken(IConsumer consumer, IUser user);
        IEnumerable<KeyValuePair<string, string>> RequestHeaders { get; set; }
        IUser User { get; set; }
    }
}
