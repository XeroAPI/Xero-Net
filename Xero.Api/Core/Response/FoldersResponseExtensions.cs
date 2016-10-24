using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public static class FoldersResponseExtensions
    {
        public static Model.Folder ToFolder(this FoldersResponse response)
        {
            return new Model.Folder
            {
                Id = response.Id,
                Name = response.Name,
                IsInbox = response.IsInbox,
                FileCount = response.FileCount
            };
        }
    }
}
