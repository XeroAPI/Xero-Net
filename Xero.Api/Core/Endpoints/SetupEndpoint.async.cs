using System.Net;
using System.Threading.Tasks;
using Xero.Api.Core.Model.Setup;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface ISetupEndpoint
    {
        Task<ImportSummary> UpdateAsync(Setup setup);
        Task<ImportSummary> CreateAsync(Setup setup);
    }

    public partial class SetupEndpoint : ISetupEndpoint
    {
        public async Task<ImportSummary> UpdateAsync(Setup setup)
        {
            return HandleResponse(await _client.Client.PostAsync(_apiEndpointUrl, _client.XmlMapper.To(setup)));
        }

        public async Task<ImportSummary> CreateAsync(Setup setup)
        {
            return HandleResponse(await _client.Client.PutAsync(_apiEndpointUrl, _client.XmlMapper.To(setup)));
        }
    }
}
