using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class AttachmentsResponse : XeroResponse<Attachment>
    {
        public IList<Attachment> Attachments { get; set; }

        public override IList<Attachment> Values
        {
            get { return Attachments; }
        }
    }    
}
