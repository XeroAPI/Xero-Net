using System.Collections.Generic;
using System.Linq;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class FoldersResponse : XeroResponse<Model.Folder>
    {
        public string Name { get; set; }

        public bool IsInbox { get; set; }


        public List<Folder> Folders { get; set; }

        public override IList<Folder> Values
        {
            get { return Folders; }
        }
    }
}