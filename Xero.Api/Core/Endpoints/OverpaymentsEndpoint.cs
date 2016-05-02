﻿using System.Collections;
using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IOverpaymentsEndpoint : IXeroReadEndpoint<OverpaymentsEndpoint, Overpayment, OverpaymentsResponse>
    {
    }

    public class OverpaymentsEndpoint : XeroReadEndpoint<OverpaymentsEndpoint, Overpayment, OverpaymentsResponse>, IOverpaymentsEndpoint
    {
        public OverpaymentsEndpoint(XeroHttpClient client)
            : base(client, "/Overpayments")
        {
        }
    }
}
