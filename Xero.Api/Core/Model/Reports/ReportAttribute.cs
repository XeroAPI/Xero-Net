using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Reports
{
	[Serializable]
	[DataContract(Namespace = "")]
    public class ReportAttribute
    {
        public string Name;
        public string Description;
        public string Value;
    }
}