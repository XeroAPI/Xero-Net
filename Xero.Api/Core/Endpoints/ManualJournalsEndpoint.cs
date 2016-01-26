using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IManualJournalsEndpoint : IXeroUpdateEndpoint<ManualJournalsEndpoint, ManualJournal, ManualJournalsRequest, ManualJournalsResponse>
    {

    }

    public class ManualJournalsEndpoint
        : XeroUpdateEndpoint<ManualJournalsEndpoint, ManualJournal, ManualJournalsRequest, ManualJournalsResponse>, IManualJournalsEndpoint
    {
        public ManualJournalsEndpoint(XeroHttpClient client) :
            base(client, "/api.xro/2.0/ManualJournals")
        {
        }

        public ManualJournalsEndpoint Page(int page)
        {
            AddParameter("page", page);
            return this;
        }
    }
}