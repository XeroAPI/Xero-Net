using System.Net;
using Xero.Api.Infrastructure.Model;

namespace Xero.Api.Infrastructure.Exceptions
{
    public class BadRequestException
        : XeroApiException
    {
        public BadRequestException(ApiException apiException)
            : base(HttpStatusCode.BadRequest, apiException.Message)
        {
            ErrorNumber = apiException.ErrorNumber;
            Type = apiException.Type;            
        }

        public int ErrorNumber { get; private set; }
        public string Type { get; private set; }        
    }
}
