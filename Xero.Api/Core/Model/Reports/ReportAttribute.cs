using System.Runtime.Serialization;

namespace Xero.Api.Core.Model.Reports
{
    [DataContract(Namespace = "")]
    public class ReportAttribute
    {
        public string Name;
        public string Description;
        public string Value;
    }
}