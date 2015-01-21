using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Request;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class FilesEndpoint : XeroUpdateEndpoint<FilesEndpoint,Model.File,FilesRequest,FilesResponse>
    {
        internal FilesEndpoint(XeroHttpClient client)
            : base(client, "files.xro/1.0/Files")
        {
            Page(1);
        }

        public FolderResponse this[string guid]
        {
                get
                {
                    var endpoint = string.Format("files.xro/1.0/Folders/{0}/Files", guid);

                    var folder = HandleFolderResponse(Client
                        .Client
                        .Get(endpoint, null));

                    return folder;
                }
        }

        public FoldersResponse[] Folders
        {
            get
            {
                var endpoint = string.Format("files.xro/1.0/Folders");

                var folder = HandleFoldersResponse(Client
                    .Client
                    .Get(endpoint, null));

                return folder;
            }
        }

        public InboxResponse Inbox
        {
            get
            {
                var endpoint = string.Format("files.xro/1.0/Inbox");

                var folder = HandleInboxResponse(Client
                    .Client
                    .Get(endpoint, null));

                return folder;
            }

        }

        public FilesEndpoint Page(int page)
        {
            AddParameter("page", page);
            return this;
        }
        
        public IList<Model.File> All()
        {
            var response = HandleFileResponse(Client
                .Client.Get("files.xro/1.0/Files","" ));

            return response.Items;
        }

        private FilesResponse HandleFileResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = Client.JsonMapper.From<FilesResponse>(response.Body);
                return result;
            }

            Client.HandleErrors(response);

            return null;
        }

        private FoldersResponse[] HandleFoldersResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Body;

                var result = Client.JsonMapper.From<FoldersResponse[]>(json);

                return result ;
            }

            Client.HandleErrors(response);

            return null;
        }

        private FolderResponse HandleFolderResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Body;

               var result = Client.JsonMapper.From<FolderResponse>(json);
               
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

    }
}