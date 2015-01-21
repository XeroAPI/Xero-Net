using System;
using System.Collections.Generic;
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

        public FolderResponse[] Folders
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

        public FolderResponse Inbox
        {
            get
            {
                var endpoint = string.Format("files.xro/1.0/Inbox");

                var folder = HandleFolderResponse(Client
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

        public FilesEndpoint Organisation(Guid organisationId)
        {
            AddParameter("OrganisationId", organisationId.ToString() );
            return this;
        }

        public FilesEndpoint User(Guid userId)
        {
            AddParameter("UserId", userId.ToString());
            return this;
        }

        public FilesResponse AddFile(Model.File file, byte[] data)
        {
            Client.Client.AddHeader("OrganisationId", Guid.NewGuid().ToString());
            Client.Client.AddHeader("UserId", Guid.NewGuid().ToString());

            var response = HandleFileResponse(Client
                .Client
                .PostMultipartForm("files.xro/1.0/Files", Guid.NewGuid().ToString(),Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), file.Name,file.Name, data));

            return response;
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
        
        private FolderResponse[] HandleFoldersResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {

                var json = response.Body;

                var result = Client.JsonMapper.From<FolderResponse[]>(json);

                return result;
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
    }

}