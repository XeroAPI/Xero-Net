using Xero.Api.Common;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Core.Endpoints.Base
{
    public abstract class FourDecimalPlacesEndpoint<T, TResult, TRequest, TResponse>
        : XeroUpdateEndpoint<T, TResult, TRequest, TResponse>
        where T : FourDecimalPlacesEndpoint<T, TResult, TRequest, TResponse>
        where TResponse : IXeroResponse<TResult>, new()
        where TRequest : IXeroRequest<TResult>, new()
    {
        protected FourDecimalPlacesEndpoint(XeroHttpClient client, string apiEndpointUrl) : base(client, apiEndpointUrl)
        {
            UseFourDecimalPlaces(true);
        }

        public override void ClearQueryString()
        {
            base.ClearQueryString();
            UseFourDecimalPlaces(true);
        }
    }
}
