using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class InboxEndpoint : XeroUpdateEndpoint<InboxEndpoint,Model.Folder,FolderRequest,FolderResponse>
    {

        internal InboxEndpoint(XeroHttpClient client)
            : base(client, "files.xro/1.0/Inbox")
        {
            
        }

        private Guid Inbox
        {
            get
            {
                var endpoint = string.Format("files.xro/1.0/Inbox");

                var folder = HandleInboxResponse(Client
                    .Client
                    .Get(endpoint, null));

                return folder.Id; 
            }

        }

        public FilesResponse Add(string contentType, Model.File file, byte[] data)
        {

            var response = HandleFileResponse(Client
                .Client
                .PostMultipartForm("files.xro/1.0/Files", Inbox, contentType, file.Name, file.Name, data));

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
        //public IList<Model.Folder> Find()
        //{
        //    var response = HandleFoldersResponse(Client
        //        .Client.Get("files.xro/1.0/Inbox", ""));


        //    var resultingFolders = from i  in response
        //        select new Folder(){Id = i.Id,Name = i.Name,IsInbox = i.IsInbox,FileCount = i.FileCount};

        //    return resultingFolders.ToList();
        //}

       

        //public FoldersResponse[] Folders
        //{
        //    get
        //    {
        //        var endpoint = string.Format("files.xro/1.0/Inbox");

        //        var folder = HandleFoldersResponse(Client
        //            .Client
        //            .Get(endpoint, null));

        //        return folder;
        //    }
        //}

        public Folder InboxFolder
        {
            get
            {
                var endpoint = string.Format("files.xro/1.0/Inbox");

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