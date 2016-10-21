using System;
using System.Threading.Tasks;
using Xero.Api.Core;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Example.TokenStores
{
    public partial class SqliteTokenStore : IAsyncTokenStore
    {
        public Task<IToken> FindAsync(string userId)
        {
            return new Func<IToken>(() => Find(userId)).StartLongRunningAsync();
        }

        public Task AddAsync(IToken token)
        {
            return new Action(() => Add(token)).StartLongRunningAsync();
        }

        public Task DeleteAsync(IToken token)
        {
            return new Action(() => Delete(token)).StartLongRunningAsync();
        }
    }
}
