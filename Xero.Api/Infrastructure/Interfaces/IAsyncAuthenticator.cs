using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAsyncAuthenticator
    {
        string GetSignature(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1);

        Task<IToken> GetTokenAsync(IConsumer consumer, IUser user);

        IUser User
        {
            get; set;
        }
    }
}
