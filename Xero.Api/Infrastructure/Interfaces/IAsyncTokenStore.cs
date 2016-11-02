using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAsyncTokenStore
    {
        Task<IToken> FindAsync(string user, CancellationToken cancellation = default(CancellationToken));

        Task AddAsync(IToken token, CancellationToken cancellation = default(CancellationToken));

        Task DeleteAsync(IToken token, CancellationToken cancellation = default(CancellationToken));
    }
}
