using System.Collections.Generic;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IXeroResponse<T>
    {
        IList<T> Values { get; }
    }
}