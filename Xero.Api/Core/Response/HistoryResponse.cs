using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class HistoryResponse : XeroResponse<History>
    {
        public List<History> HistoryRecords { get; set; }

        public override IList<History> Values
        {
            get { return HistoryRecords; }
        }
    }
}