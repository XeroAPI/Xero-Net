﻿using System.Collections.Specialized;
using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IJournalsEndpoint : IXeroReadEndpoint<JournalsEndpoint, Journal, JournalsResponse>
    {
        JournalsEndpoint Offset(int offset);
    }

    public class JournalsEndpoint : XeroReadEndpoint<JournalsEndpoint, Journal, JournalsResponse>, IJournalsEndpoint
    {
        public JournalsEndpoint(XeroHttpClient client) :
            base(client, "/api.xro/2.0/Journals")
        {
        }

        public JournalsEndpoint Offset(int offset)
        {
            AddParameter("offset", offset);
            return this;
        }
    }
}