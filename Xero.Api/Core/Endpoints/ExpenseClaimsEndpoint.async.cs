using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IExpenseClaimsEndpoint : IAsyncXeroUpdateEndpoint<ExpenseClaimsEndpoint, ExpenseClaim, ExpenseClaimsRequest, ExpenseClaimsResponse>
    {

    }
}