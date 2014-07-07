using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Payroll.America.Model;

namespace Xero.Api.Payroll.America.Request
{
    [CollectionDataContract(Namespace = "", Name = "PayStubs")]
    public class PayStubsRequest : XeroRequest<PayStub>
    {
    }
}