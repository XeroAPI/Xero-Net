using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAsyncAuthenticator
    {
        Task<string> GetSignatureAsync(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1);

        Task<string> GetSignatureAsync(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1, CancellationToken cancellation);

        Task<IToken> GetTokenAsync(IConsumer consumer, IUser user);

        Task<IToken> GetTokenAsync(IConsumer consumer, IUser user, CancellationToken cancellation);

        IUser User
        {
            get; set;
        }
    }
}
