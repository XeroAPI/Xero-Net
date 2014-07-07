using System.Collections.Generic;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IXeroRequest<T>
    {
        IList<T> Items { get; }
        void Add(T value);
        void AddRange(IEnumerable<T> value);
    }
}