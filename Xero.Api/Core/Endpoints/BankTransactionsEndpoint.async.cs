using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xero.Api.Common;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IBankTransactionsEndpoint : IAsyncXeroUpdateEndpoint<BankTransactionsEndpoint, BankTransaction, BankTransactionsRequest, BankTransactionsResponse>, IPageableEndpoint<IBankTransactionsEndpoint>
    {
    }
}
