﻿using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface ICreditNotesEndpoint :
        IXeroUpdateEndpoint<CreditNotesEndpoint, CreditNote, CreditNotesRequest, CreditNotesResponse>
    {
        
    }

    public class CreditNotesEndpoint
        : FourDecimalPlacesEndpoint<CreditNotesEndpoint, CreditNote, CreditNotesRequest, CreditNotesResponse>, ICreditNotesEndpoint
    {
        public CreditNotesEndpoint(XeroHttpClient client) :
            base(client, "/CreditNotes")
        {
        }        
    }
}