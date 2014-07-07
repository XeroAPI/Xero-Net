using System;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAuthenticator
    {
        string GetSignature(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1);
        IToken GetToken(IConsumer consumer, IUser user);

        IUser User { get; set; }
    }
}
