using System;
using System.Collections.Generic;
using System.Net;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IHistoryAndNotesEndpoint
    {
        IEnumerable<HistoryRecord> Find(HistoryAndNotesEndpointRetrieveType type, Guid parent);
        void CreateNote(HistoryAndNotesEndpointCreateType type, Guid parent, HistoryRecord note);
    }

    public class HistoryAndNotesEndpoint : IHistoryAndNotesEndpoint
    {
        private XeroHttpClient Client { get; set; }

        public HistoryAndNotesEndpoint(XeroHttpClient client)
        {
            Client = client;
        }

        public IEnumerable<HistoryRecord> Find(HistoryAndNotesEndpointRetrieveType type, Guid parent)
        {
            return Client.Get<HistoryRecord, HistoryRecordsResponse>(string.Format("api.xro/2.0/{0}/{1:D}/history", type, parent));
        }

        public void CreateNote(HistoryAndNotesEndpointCreateType type, Guid parent, HistoryRecord note)
        {
            var response = Client.Client.Put(string.Format("api.xro/2.0/{0}/{1:D}/history", type, parent), Client.XmlMapper.To(new List<HistoryRecord>{note}));

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Client.HandleErrors(response);
            }
        }
    }
}