using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Core.Model.Setup;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface ISetupEndpoint
    {
        Task<ImportSummary> UpdateAsync(Setup setup, CancellationToken cancellation = default(CancellationToken));
        Task<ImportSummary> CreateAsync(Setup setup, CancellationToken cancellation = default(CancellationToken));
    }

    public partial class SetupEndpoint : ISetupEndpoint
    {
        public async Task<ImportSummary> UpdateAsync(Setup setup, CancellationToken cancellation = default(CancellationToken))
        {
            return HandleResponse(await _client.Client.PostAsync(_apiEndpointUrl, _client.XmlMapper.To(setup), cancellation: cancellation));
        }

        public async Task<ImportSummary> CreateAsync(Setup setup, CancellationToken cancellation = default(CancellationToken))
        {
            return HandleResponse(await _client.Client.PutAsync(_apiEndpointUrl, _client.XmlMapper.To(setup), cancellation: cancellation));
        }
    }
}
