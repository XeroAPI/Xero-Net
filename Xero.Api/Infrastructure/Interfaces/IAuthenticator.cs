using System;
using System.Collections.Generic;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAuthenticator
    {
        string GetSignature(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1, IEnumerable<KeyValuePair<string, string>> additionalParameters = null);
        IToken GetToken(IConsumer consumer, IUser user);

        IUser User { get; set; }
    }
}
