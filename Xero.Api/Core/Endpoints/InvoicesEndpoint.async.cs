using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;

namespace Xero.Api.Core.Endpoints
{
    partial interface IInvoicesEndpoint : IAsyncXeroUpdateEndpoint<InvoicesEndpoint, Invoice, InvoicesRequest, InvoicesResponse>
    {
        Task<OnlineInvoice> RetrieveOnlineInvoiceUrlAsync(Guid invoiceId, CancellationToken cancellation = default(CancellationToken));
    }

    partial class InvoicesEndpoint
    {
        public async Task<OnlineInvoice> RetrieveOnlineInvoiceUrlAsync(Guid invoiceId, CancellationToken cancellation = default(CancellationToken))
        {
            return (await Client.GetAsync<OnlineInvoice, OnlineInvoicesResponse>(string.Format("/api.xro/2.0/Invoices/{0}/OnlineInvoice", invoiceId), cancellation: cancellation)).FirstOrDefault();
        }
    }
}
