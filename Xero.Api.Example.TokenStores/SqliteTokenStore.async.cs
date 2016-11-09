using System;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Core;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Example.TokenStores
{
    public partial class SqliteTokenStore : IAsyncTokenStore
    {
        public Task<IToken> FindAsync(string userId, CancellationToken cancellation)
        {
            return new Func<IToken>(() => Find(userId)).StartLongRunningAsync(cancellation);
        }

        public Task AddAsync(IToken token, CancellationToken cancellation)
        {
            return new Action(() => Add(token)).StartLongRunningAsync(cancellation);
        }

        public Task DeleteAsync(IToken token, CancellationToken cancellation)
        {
            return new Action(() => Delete(token)).StartLongRunningAsync(cancellation);
        }
    }
}
