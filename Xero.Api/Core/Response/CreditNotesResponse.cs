using System.Collections.Generic;
using System.Runtime.Serialization;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    [CollectionDataContract(Name = "CreditNotes", Namespace = "")]
    public class CreditNotesResponse : XeroResponse<CreditNote>
    {
        public IList<CreditNote> CreditNotes { get; set; }

        public override IList<CreditNote> Values
        {
            get{ return CreditNotes;}
        }
    }
}