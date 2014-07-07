using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Request
{
    [CollectionDataContract(Namespace = "", Name = "Accounts")]
    public class AccountsRequest : XeroRequest<Account>
    {
    }
}