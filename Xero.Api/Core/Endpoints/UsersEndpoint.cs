using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IUsersEndpoint : IXeroReadEndpoint<IUsersEndpoint, User, UsersResponse>
    {
    }

    public class UsersEndpoint : XeroReadEndpoint<IUsersEndpoint, User, UsersResponse>, IUsersEndpoint
    {
        internal UsersEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/Users")
        {
        }
    }
}