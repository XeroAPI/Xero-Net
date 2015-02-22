using System;

namespace Xero.Api.Common
{
    public interface IHasId
    {
        Guid Id { get; set; }
    }
}
