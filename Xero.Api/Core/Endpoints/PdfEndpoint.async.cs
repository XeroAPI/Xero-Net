using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Core.File;
using Xero.Api.Core.Model.Types;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial class PdfEndpoint
    {
        public async Task<BinaryFile> GetAsync(PdfEndpointType type, Guid parent, CancellationToken cancellation = default(CancellationToken))
        {
            var data = await Client.Client.GetRawAsync(string.Format("/api.xro/2.0/{0}/{1}", type, parent.ToString("D")), "application/pdf", cancellation: cancellation);

            if (data.StatusCode == HttpStatusCode.OK)
            {
                return new BinaryFile(data.Stream, parent.ToString("D") + ".pdf", data.ContentType, data.ContentLength);
            }

            Client.HandleErrors(data);

            return null;
        }
    }
}
