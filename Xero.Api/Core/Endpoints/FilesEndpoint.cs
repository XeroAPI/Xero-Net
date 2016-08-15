using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IFilesEndpoint : IXeroUpdateEndpoint<FilesEndpoint, Model.File, FilesRequest, FilesResponse>
    {
        Model.File Rename(Guid id, string name);
        Model.File Move(Guid id, Guid newFolder);
        Model.File Add(Guid folderId, Model.File file, byte[] data);
        Model.File Remove(Guid fileid);
        byte[] GetContent(Guid id, string contentType);
        Model.File this[Guid id] { get; }
    }

    public class FilesEndpoint : XeroUpdateEndpoint<FilesEndpoint, Model.File, FilesRequest, FilesResponse>, IFilesEndpoint
    {
        public static string BASE_URI_PATH = "/files.xro/1.0/Files";

        public FilesEndpoint(XeroHttpClient client) : base(client, BASE_URI_PATH)
        {
            client.TrimBaseUri();
        }

        public Model.File this[Guid id]
        {
            get
            {
                var result = Find(id);
                return result;
            }
        }

        public override IEnumerable<Model.File> Find()
        {
            var response = HandleFilesResponse(Client
                .Client.Get(BASE_URI_PATH, ""));

            return response.Items;
        }

        public override Model.File Find(Guid fileId)
        {
            var response = HandleFilesResponse(Client
                .Client.Get(BASE_URI_PATH, ""));

            return response.Items.SingleOrDefault(i => i.Id == fileId);
        }

        public Model.File Rename(Guid id, string name)
        {
            var response = HandleFileResponse(Client
                .Client.Put(UriPath(id), "{\"Name\":\"" + name + "\"}", "application/json"));

            return response;
        }

        public Model.File Move(Guid id, Guid newFolder)
        {
            var response = HandleFileResponse(Client
                .Client.Put(UriPath(id), "{\"FolderId\":\"" + newFolder + "\"}", "application/json"));

            return response;
        }

        public Model.File Add(Guid folderId, Model.File file, byte[] data)
        {
            var response = HandleFileResponse(Client
                .Client
                .PostMultipartForm(UriPath(folderId), file.Mimetype, file.Name, file.FileName, data));

            return response;
        }

        public Model.File Remove(Guid fileid)
        {
            var response = HandleFileResponse(Client
                .Client
                .Delete(UriPath(fileid)));

            return response;
        }

        public byte[] GetContent(Guid id, string contentType)
        {
            var response = Client.Client.GetRaw(UriPath(id, "Content"), contentType, "");

            using (MemoryStream ms = new MemoryStream())
            {
                response.Stream.CopyTo(ms);

                return ms.ToArray();
            }
        }

        private static string UriPath(params object[] parts)
        {
            return Internal.Url.From(BASE_URI_PATH, parts);
        }

        private Model.File HandleFileResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var body = response.Body;

                var result = Client.JsonMapper.From<Model.File>(body);
                return result;
            }

            Client.HandleErrors(response);

            return null;
        }

        private FilesResponse HandleFilesResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var body = response.Body;

                var result = Client.JsonMapper.From<FilesResponse>(body);
                return result;
            }

            Client.HandleErrors(response);

            return null;
        }
    }
}