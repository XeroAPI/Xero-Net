using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class InvoicesEndpoint
        : FourDecimalPlacesEndpoint<InvoicesEndpoint, Invoice, InvoicesRequest, InvoicesResponse>
    {
        internal InvoicesEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/Invoices")
        {
            Page(1);
        }

        public InvoicesEndpoint Page(int page)
        {
            AddParameter("page", page);
            return this;
        }

        public override void ClearQueryString()
        {
            base.ClearQueryString();
            Page(1);
        }        
    }
}
