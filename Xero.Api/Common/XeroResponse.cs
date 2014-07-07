using System;
using System.Collections.Generic;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Common
{
    public abstract class XeroResponse<T> : IXeroResponse<T>
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string ProviderName { get; set; }
        public DateTime DateTime { get; set; }

        public abstract IList<T> Values { get; }
    }
}