using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAsyncTokenStore
    {
        Task<IToken> FindAsync(string user);

        Task AddAsync(IToken token);

        Task DeleteAsync(IToken token);
    }
}
