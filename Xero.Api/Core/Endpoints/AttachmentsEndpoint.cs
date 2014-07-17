using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class AttachmentsEndpoint
    {
        private XeroHttpClient Client { get; set; }

        public AttachmentsEndpoint(XeroHttpClient client)
        {
            Client = client;
        }

        public IEnumerable<Attachment> List(AttachmentEndpointType type, Guid parent)
        {
            return Client.Get<Attachment, AttachmentsResponse>(string.Format("/api.xro/2.0/{0}/{1}/Attachments", type, parent.ToString("D")));
        }

        public Attachment Get(AttachmentEndpointType type, Guid parent, string fileName)
        {

            var mimeType = MimeTypes.GetMimeType(fileName);
            var data = Client.Get(string.Format("/api.xro/2.0/{0}/{1}/Attachments/{2}", type, parent.ToString("D"), fileName), mimeType);

            if (data.StatusCode == HttpStatusCode.OK)
            {
                return new Attachment(data.Stream, fileName, data.ContentType, data.ContentLength);
            }

            Client.HandleErrors(data);
            return null;
        }

        public Attachment AddOrReplace(Attachment attachment, AttachmentEndpointType type, Guid parent, bool includeOnline = false)
        {
            var mimeType = MimeTypes.GetMimeType(attachment.FileName);

            var url = string.Format("/api.xro/2.0/{0}/{1}/Attachments/{2}", type, parent.ToString("D"), attachment.FileName);

            if (SupportsOnline(type) && includeOnline)
            {
                Client.Parameters = new NameValueCollection { { "IncludeOnline", "true" } };
            }

            return Client.Post<Attachment, AttachmentsResponse>(url, attachment.Content, mimeType).FirstOrDefault();
        }

        private static bool SupportsOnline(AttachmentEndpointType type)
        {
            return type == AttachmentEndpointType.Invoices || type == AttachmentEndpointType.CreditNotes;
        }
    }
}
