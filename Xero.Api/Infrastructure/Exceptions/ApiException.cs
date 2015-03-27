using System.Collections.Generic;
using Xero.Api.Infrastructure.Model;

namespace Xero.Api.Infrastructure.Exceptions
{
    public class ApiException
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public int ErrorNumber { get; set; }

        public List<DataContractBase> Elements { get; set; }
    }
}