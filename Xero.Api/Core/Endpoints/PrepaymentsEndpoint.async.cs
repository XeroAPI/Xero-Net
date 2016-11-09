using System.Collections;
using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IPrepaymentsEndpoint : IAsyncXeroReadEndpoint<PrepaymentsEndpoint, Prepayment, PrepaymentsResponse>
    {
    }
}
