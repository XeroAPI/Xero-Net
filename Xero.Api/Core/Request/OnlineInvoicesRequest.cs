﻿using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Endpoints;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Request
{
    [CollectionDataContract(Namespace = "", Name = "OnlineInvoices")]
    public class OnlineInvoicesRequest : XeroRequest<OnlineInvoice>
    {
    }
}