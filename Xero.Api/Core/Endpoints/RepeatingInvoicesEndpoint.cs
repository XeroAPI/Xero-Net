﻿using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IRepeatingInvoicesEndpoint : IXeroReadEndpoint<IRepeatingInvoicesEndpoint, RepeatingInvoice, RepeatingInvoicesResponse>
    {
    }

    public class RepeatingInvoicesEndpoint
        : XeroReadEndpoint<IRepeatingInvoicesEndpoint, RepeatingInvoice, RepeatingInvoicesResponse>, IRepeatingInvoicesEndpoint
    {
        public RepeatingInvoicesEndpoint(XeroHttpClient client) :
            base(client, "/api.xro/2.0/RepeatingInvoices")
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