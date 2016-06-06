using System;
using System.Collections.Generic;
using System.Linq;
using Xero.Api.Common;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IInvoicesEndpoint : IXeroUpdateEndpoint<InvoicesEndpoint, Invoice, InvoicesRequest, InvoicesResponse>, IPageableEndpoint<IInvoicesEndpoint>
    {
        OnlineInvoice RetrieveOnlineInvoiceUrl(Guid invoiceId);
    }

    public class InvoicesEndpoint
        : FourDecimalPlacesEndpoint<InvoicesEndpoint, Invoice, InvoicesRequest, InvoicesResponse>, IInvoicesEndpoint
    {
        internal InvoicesEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/Invoices")
        {
            Page(1);
        }

        public IInvoicesEndpoint Page(int page)
        {
            AddParameter("page", page);
            return this;
        }

        public override void ClearQueryString()
        {
            base.ClearQueryString();
            Page(1);
        }

        public OnlineInvoice RetrieveOnlineInvoiceUrl(Guid invoiceId)
        {
            return Client.Get<OnlineInvoice, OnlineInvoicesResponse>(string.Format("/api.xro/2.0/Invoices/{0}/OnlineInvoice", invoiceId)).FirstOrDefault();
        }
    }
}
