using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [Obsolete("Use CreditNoteAllocation")]
    [DataContract(Namespace = "")]
    public class Allocation : CreditNoteAllocation
    {
    }
}