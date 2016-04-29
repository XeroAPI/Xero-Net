using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Endpoints.Internal;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IInboxEndpoint : IXeroUpdateEndpoint<InboxEndpoint, Model.Folder, FolderRequest, FolderResponse>
    {
        Model.File this[Guid id] { get; }
        FilesResponse Add(Model.File file, byte[] data);
        FilesResponse Remove(Guid fileid);
        Folder InboxFolder { get; }
    }

    public class InboxEndpoint : XeroUpdateEndpoint<InboxEndpoint,Model.Folder,FolderRequest,FolderResponse>, IInboxEndpoint
    {
        public InboxEndpoint(XeroHttpClient client)
            : base(client, "/Inbox")
        {
            client.TrimBaseUri();
        }

        private Guid Inbox
        {
            get
            {
                var endpoint = string.Format("/Inbox");

                var folder = HandleInboxResponse(Client
                    .Client
                    .Get(endpoint, null));

                return folder.Id; 
            }

        }

        public Model.File this[Guid id]
        {
            get
            {
                var result = Find(id);
                return result;
            }
        }

        public Model.File Find(Guid fileId)
        {
            var response = HandleFileResponse(Client
                .Client.Get("/Files", ""));

            return response.Items.SingleOrDefault(i => i.Id == fileId);
        }

        public FilesResponse Add(Model.File file, byte[] data)
        {

            var response = HandleFileResponse(Client
                .Client
                .PostMultipartForm("/Files/" + Inbox, file.Mimetype , file.Name, file.Name, data));

            return response;
        }


     

        public FilesResponse Remove(Guid fileid)
        {
            var response = HandleFileResponse(Client
                .Client
                .Delete("/Files/" + fileid.ToString()));

            return response;
        }

        private FilesResponse HandleFileResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var result = Client.JsonMapper.From<FilesResponse>(response.Body);
                return result;
            }

            Client.HandleErrors(response);

            return null;
        }

        private InboxResponse HandleInboxResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Body;

                var result = Client.JsonMapper.From<InboxResponse>(json);

                return result;
            }

            Client.HandleErrors(response);

            return null;
        }
      

        public Folder InboxFolder
        {
            get
            {
                var endpoint = string.Format("{0}/Inbox", FilesApi.BaseUriPath);

                var folder = HandleFoldersResponse(Client
                    .Client
                    .Get(endpoint, null));

                var resultingFolders = from i in folder
                                       select new Folder() { Id = i.Id, Name = i.Name, IsInbox = i.IsInbox, FileCount = i.FileCount };

                return resultingFolders.First();
            }
        }

        private FoldersResponse[] HandleFoldersResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Body;

                var result = Client.JsonMapper.From<FoldersResponse[]>(json);

                return result;
            }

            Client.HandleErrors(response);

            return null;
        }

    }
}