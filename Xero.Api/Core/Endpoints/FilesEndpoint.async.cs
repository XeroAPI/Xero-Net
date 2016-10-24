using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IFilesEndpoint : IAsyncXeroUpdateEndpoint<FilesEndpoint, Model.File, FilesRequest, FilesResponse>
    {
        Task<Model.File> RenameAsync(Guid id, string name, CancellationToken cancellation = default(CancellationToken));
        Task<Model.File> MoveAsync(Guid id, Guid newFolder, CancellationToken cancellation = default(CancellationToken));
        Task<Model.File> AddAsync(Guid folderId, Model.File file, byte[] data, CancellationToken cancellation = default(CancellationToken));
        Task<Model.File> RemoveAsync(Guid fileid, CancellationToken cancellation = default(CancellationToken));
        Task<byte[]> GetContentAsync(Guid id, string contentType, CancellationToken cancellation = default(CancellationToken));
        Task<Model.File> GetAsync(Guid id, CancellationToken cancellation = default(CancellationToken));
    }

    public partial class FilesEndpoint : XeroUpdateEndpoint<FilesEndpoint, Model.File, FilesRequest, FilesResponse>, IFilesEndpoint
    {
        public Task<Model.File> GetAsync(Guid id, CancellationToken cancellation)
        {
            return FindAsync(id, cancellation);
        }

        public override async Task<IList<Model.File>> FindAsync(CancellationToken cancellation)
        {
            var response = HandleFilesResponse(await Client.Client.GetAsync("files.xro/1.0/Files", string.Empty, cancellation));
            return response.Items;
        }

        public override async Task<Model.File> FindAsync(Guid fileId, CancellationToken cancellation)
        {
            var response = HandleFilesResponse(await Client.Client.GetAsync("files.xro/1.0/Files", string.Empty, cancellation));
            return response.Items.SingleOrDefault(i => i.Id == fileId);
        }

        public async Task<Model.File> RenameAsync(Guid id, string name, CancellationToken cancellation)
        {
            var response = HandleFileResponse(await Client.Client.PutAsync("files.xro/1.0/Files/" + id, "{\"Name\":\"" + name + "\"}", "application/json", cancellation: cancellation));
            return response;
        }

        public async Task<Model.File> MoveAsync(Guid id, Guid newFolder, CancellationToken cancellation)
        {
            var response = HandleFileResponse(await Client.Client.PutAsync("files.xro/1.0/Files/" + id, "{\"FolderId\":\"" + newFolder + "\"}", "application/json", cancellation: cancellation));
            return response;
        }

        public async Task<Model.File> AddAsync(Guid folderId, Model.File file, byte[] data, CancellationToken cancellation)
        {
            var response = HandleFileResponse(await Client.Client.PostMultipartFormAsync("files.xro/1.0/Files/" + folderId, file.Mimetype, file.Name, file.FileName, data, cancellation));
            return response;
        }

        public async Task<Model.File> RemoveAsync(Guid fileid, CancellationToken cancellation)
        {
            var response = HandleFileResponse(await Client.Client.DeleteAsync("files.xro/1.0/Files/" + fileid.ToString(), cancellation));

            return response;
        }

        public async Task<byte[]> GetContentAsync(Guid id, string contentType, CancellationToken cancellation)
        {
            var response = await Client.Client.GetRawAsync("files.xro/1.0/Files/" + id + "/Content", contentType, string.Empty, cancellation);

            using (MemoryStream ms = new MemoryStream())
            {
                await response.Stream.CopyToAsync(ms, response.ContentLength, cancellation);

                return ms.ToArray();
            }

        }
    }
}