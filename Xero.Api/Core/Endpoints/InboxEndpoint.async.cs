using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IInboxEndpoint : IAsyncXeroUpdateEndpoint<InboxEndpoint, Model.Folder, FolderRequest, FolderResponse>
    {
        Task<Model.File> GetAsync(Guid id, CancellationToken cancellation = default(CancellationToken));
        Task<FilesResponse> AddAsync(Model.File file, byte[] data, CancellationToken cancellation = default(CancellationToken));
        Task<FilesResponse> RemoveAsync(Guid fileid, CancellationToken cancellation = default(CancellationToken));
        Task<Folder> GetFolderAsync(CancellationToken cancellation = default(CancellationToken));
    }

    public partial class InboxEndpoint : XeroUpdateEndpoint<InboxEndpoint,Model.Folder,FolderRequest,FolderResponse>, IInboxEndpoint
    {
        public Task<Model.File> GetAsync(Guid id, CancellationToken cancellation = default(CancellationToken))
        {
            return FindAsync(id, cancellation);
    }

        public new async Task<Model.File> FindAsync(Guid fileId, CancellationToken cancellation = default(CancellationToken))
        {
            var response = HandleFileResponse(await Client.Client.GetAsync("files.xro/1.0/Files", string.Empty, cancellation));
            return response.Items.SingleOrDefault(i => i.Id == fileId);
        }

        public async Task<FilesResponse> AddAsync(Model.File file, byte[] data, CancellationToken cancellation = default(CancellationToken))
        {

            var response = HandleFileResponse(await Client.Client.PostMultipartFormAsync("files.xro/1.0/Files/" + Inbox, file.Mimetype , file.Name, file.Name, data, cancellation));
            return response;
        }

        public async Task<FilesResponse> RemoveAsync(Guid fileid, CancellationToken cancellation = default(CancellationToken))
        {
            var response = HandleFileResponse(await Client.Client.DeleteAsync("files.xro/1.0/Files/" + fileid.ToString(), cancellation));
            return response;
        }

        public async Task<Folder> GetFolderAsync(CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("files.xro/1.0/Inbox");
            var folder = HandleFoldersResponse(await Client.Client.GetAsync(endpoint, null));
            var resultingFolders = folder.Select(f => f.ToFolder());
            return resultingFolders.First();
        }
    }
}