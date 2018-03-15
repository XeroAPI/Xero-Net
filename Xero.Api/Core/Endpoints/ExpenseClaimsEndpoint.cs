using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IExpenseClaimsEndpoint : IXeroUpdateEndpoint<IExpenseClaimsEndpoint, ExpenseClaim, ExpenseClaimsRequest, ExpenseClaimsResponse>
    {

    }

    public class ExpenseClaimsEndpoint
        : XeroUpdateEndpoint<IExpenseClaimsEndpoint, ExpenseClaim, ExpenseClaimsRequest, ExpenseClaimsResponse>, IExpenseClaimsEndpoint
    {
        public ExpenseClaimsEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/ExpenseClaims")
        {            
        }
    }
}