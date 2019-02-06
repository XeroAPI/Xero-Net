using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Reports
{
	[Serializable]
	[DataContract(Namespace = "", Name = "Row")]
    public class ReportRow
    {
        [DataMember]
        public string RowType { get; set; }

        [DataMember]
        public List<ReportCell> Cells { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public List<ReportRow> Rows { get; set; }
    }
}