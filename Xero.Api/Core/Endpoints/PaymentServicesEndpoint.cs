using System;
using System.Collections.Generic;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IPaymentServicesEndpoint
        : IXeroUpdateEndpoint<PaymentServicesEndpoint, PaymentService, PaymentServicesRequest, PaymentServicesResponse>
    {

		/// <summary>
		/// Add a Custom Payment Service
		/// </summary>
		IEnumerable<PaymentService> Get(Guid brandingThemeId);

		/// <summary>
		/// Add a Payment Service to a Branding Theme
		/// </summary>
		void AddPaymentServiceToBrandingTheme(Guid brandingThemeId, Guid paymentServiceId);

	}

    public class PaymentServicesEndpoint
		: XeroUpdateEndpoint<PaymentServicesEndpoint, PaymentService, PaymentServicesRequest, PaymentServicesResponse>, IPaymentServicesEndpoint
	{
        public PaymentServicesEndpoint(XeroHttpClient client) :
            base(client, "/api.xro/2.0/PaymentServices")
        {
        }

		/// <summary>
		/// List payment services for a given Branding Theme
		/// </summary>
		///
		/// <param name="brandingThemeId">Id of the Branding Theme</param>
		///
		/// <returns>List of PaymentServices enabled for this Branding Theme</returns>
		public IEnumerable<PaymentService> Get(Guid brandingThemeId)
		{
			var found = Client.Get<PaymentService, PaymentServicesResponse>(string.Format("api.xro/2.0/BrandingThemes/{0:D}/PaymentServices", brandingThemeId));
			return found;
		}

		/// <summary>
		/// Add a Payment Service to a given Branding Theme
		/// </summary>
		///
		/// <param name="brandingThemeId">Id of the Branding theme to enable the payment service for</param>
		/// <param name="paymentServiceId">Id of the payment service</param>
		public void AddPaymentServiceToBrandingTheme(Guid brandingThemeId, Guid paymentServiceId)
		{
			var item = new PaymentService { Id = paymentServiceId };
			var request = new PaymentServicesRequest { item };

			Client.Post<PaymentService, PaymentServicesResponse>(string.Format("api.xro/2.0/BrandingThemes/{0:D}/PaymentServices", brandingThemeId), request);
		}

	}

}