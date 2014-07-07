using System.Collections.Specialized;
using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class JournalsEndpoint : XeroReadEndpoint<JournalsEndpoint, Journal, JournalsResponse>
    {
        public JournalsEndpoint(XeroHttpClient client) :
            base(client, "/api.xro/2.0/Journals")
        {
        }

        public JournalsEndpoint Offset(int offset)
        {
            Parameter("offset", offset);
            return this;
        }
    }
}