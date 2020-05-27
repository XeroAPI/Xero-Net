using System;
using System.Runtime.Serialization;
using Xero.Api.Common;

namespace Xero.Api.Core.Model
{
	/// <summary>
	/// See Xero developer site for more info https://developer.xero.com/documentation/api/payment-services
	/// </summary>
	[DataContract(Namespace = "")]
    public class PaymentService : CoreData, IHasId
    {
        [DataMember(Name = "PaymentServiceID")]
        public Guid Id { get; set; }

		[DataMember]
		public string PaymentServiceName { get; set; }

		[DataMember]
		public string PaymentServiceUrl { get; set; }

		[DataMember]
		public string PayNowText { get; set; }

		/// <summary>
		/// This will always be CUSTOM for payment services created via the API.
		/// </summary>
		[DataMember]
		public string PaymentServiceType { get; set; }
    }
}