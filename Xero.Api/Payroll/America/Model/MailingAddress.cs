using System.Runtime.Serialization;

namespace Xero.Api.Payroll.America.Model
{
    [DataContract(Namespace = "")]
    public class MailingAddress : Address
    {
        [DataMember(Name = "SuiteOrAptOrUnit")]
        public string SuiteOrApartmentOrUnit { get; set; }
    }
}