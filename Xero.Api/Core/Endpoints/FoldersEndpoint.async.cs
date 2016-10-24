using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Common;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IFoldersEndpoint : IAsyncXeroUpdateEndpoint<FoldersEndpoint, Model.Folder, FolderRequest, FolderResponse>
    {
        Task<FoldersResponse[]> GetFoldersAsync(CancellationToken cancellation = default(CancellationToken));
        Task<FilePageResponse> AddAsync(string folderName, CancellationToken cancellation = default(CancellationToken));
        Task RemoveAsync(Guid id, CancellationToken cancellation = default(CancellationToken));
        Task<FoldersResponse> RenameAsync(Guid id, string name, CancellationToken cancellation = default(CancellationToken));
    }

    public partial class FoldersEndpoint : XeroUpdateEndpoint<FoldersEndpoint, Model.Folder, FolderRequest, FolderResponse>, IFoldersEndpoint
    {
        public async Task<FoldersResponse[]> GetFoldersAsync(CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("files.xro/1.0/Folders");

            var folder = HandleFoldersResponse(await Client.Client.GetAsync(endpoint, null, cancellation));

            return folder;
        }

        public async Task<FilePageResponse> AddAsync(string folderName, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("files.xro/1.0/Folders");

            var result = HandleFolderResponse(await Client.Client.PostAsync(endpoint, Client.JsonMapper.To(new Folder() { Name = folderName }), contentType: "application/json", cancellation: cancellation));

            return result;
        }

        public override async Task<IList<Model.Folder>> FindAsync(CancellationToken cancellation = default(CancellationToken))
        {
            var response = HandleFoldersResponse(await Client.Client.GetAsync("files.xro/1.0/Folders", string.Empty, cancellation));

            var resultingFolders = response.Select(f => f.ToFolder()).ToList();

            return resultingFolders.ToList();
        }

        public async Task RemoveAsync(Guid id, CancellationToken cancellation = default(CancellationToken))
        {
            var response = HandleFolderResponse(await Client.Client.DeleteAsync("files.xro/1.0/Folders/" + id.ToString(), cancellation));
        }

        public async Task<FoldersResponse> RenameAsync(Guid id, string name, CancellationToken cancellation = default(CancellationToken))
        {
            var response = HandleFoldersResponse(await Client.Client.PutAsync("files.xro/1.0/Folders/" + id, "{\"Name\":\"" + name + "\"}", "application/json", cancellation: cancellation));
            return (response != null) ? response[0] : null;
        }
    }
}