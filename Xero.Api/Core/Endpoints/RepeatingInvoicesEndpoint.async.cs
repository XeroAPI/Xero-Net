using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IRepeatingInvoicesEndpoint : IAsyncXeroReadEndpoint<RepeatingInvoicesEndpoint, RepeatingInvoice, RepeatingInvoicesResponse>
    {
    }
}