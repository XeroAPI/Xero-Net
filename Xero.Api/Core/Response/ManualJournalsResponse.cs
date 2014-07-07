using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class ManualJournalsResponse : XeroResponse<ManualJournal>
    {
        public IList<ManualJournal> ManualJournals { get; set; }

        public override IList<ManualJournal> Values
        {
            get { return ManualJournals; }
        }
    }
}