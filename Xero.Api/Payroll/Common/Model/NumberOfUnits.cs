using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Payroll.Common.Model
{
    [CollectionDataContract(Namespace = "", ItemName = "NumberOfUnit")]
    public class NumberOfUnits : List<decimal>
    {
    }
}