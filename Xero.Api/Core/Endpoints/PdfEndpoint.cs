using System;
using System.Net;
using Xero.Api.Core.File;
using Xero.Api.Core.Model.Types;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class PdfEndpoint
    {
        private XeroHttpClient Client { get; set; }

        public PdfEndpoint(XeroHttpClient client)
        {
            Client = client;
        }

        public BinaryFile Get(PdfEndpointType type, Guid parent)
        {
            var data = Client.Client.GetRaw(string.Format("/api.xro/2.0/{0}/{1}", type, parent.ToString("D")), "application/pdf");

            if (data.StatusCode == HttpStatusCode.OK)
            {
                return new BinaryFile(data.Stream, parent.ToString("D") + ".pdf", data.ContentType, data.ContentLength);
            }

            Client.HandleErrors(data);

            return null;
        }
    }
}
