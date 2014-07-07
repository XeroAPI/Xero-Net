using System.Collections.Generic;

namespace Xero.Api.Infrastructure.Model
{
    public class ApiException
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public int ErrorNumber { get; set; }

        public List<DataContractBase> Elements { get; set; }
    }

    public class DataContractBase
    {
        public List<ValidationError> ValidationErrors { get; set; }
    }

    public class ValidationError
    {
        public string Message { get; set; }
    }
}