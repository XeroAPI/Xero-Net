﻿using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IPaymentsEndpoint : IXeroUpdateEndpoint<PaymentsEndpoint, Payment, PaymentsRequest, PaymentsResponse>
    {

    }

    public class PaymentsEndpoint
        : FourDecimalPlacesEndpoint<PaymentsEndpoint, Payment, PaymentsRequest, PaymentsResponse>, IPaymentsEndpoint
    {
        public PaymentsEndpoint(XeroHttpClient client) :
            base(client, "/Payments")
        {
        }
    }
}