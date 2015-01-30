using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xero.Api.Common;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class FoldersEndpoint : XeroUpdateEndpoint<FoldersEndpoint,Model.Folder,FolderRequest,FolderResponse>
    {
        internal FoldersEndpoint(XeroHttpClient client)
            : base(client, "files.xro/1.0/Folders")
        {
            
        }

        public FilePageResponse Add(string folderName)
        {
            var endpoint = string.Format("files.xro/1.0/Folders");

            var result = HandleFolderResponse(Client
                .Client
                .Post(endpoint, Client.JsonMapper.To(new Folder() { Name = folderName }), contentType: "application/json"));

            return result;
        }

        public IList<Model.Folder> Find()
        {
            var response = HandleFoldersResponse(Client
                .Client.Get("files.xro/1.0/Folders", ""));


            var resultingFolders = from i  in response
                        select new Folder(){Id = i.Id,Name = i.Name,IsInbox = i.IsInbox,FileCount = i.FileCount};

            return resultingFolders.ToList();
        }

        public void Remove(Guid id)
        {

            var response = HandleFolderResponse(Client
                .Client
                .Delete("files.xro/1.0/Folders/" + id.ToString()));


        }

        private FilePageResponse HandleFolderResponse(Infrastructure.Http.Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var json = response.Body;

                var result = Client.JsonMapper.From<FilePageResponse>(json);

                return result;
            }

            Client.HandleErrors(response);

            return null;
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

    public class FolderResponse : XeroResponse<Model.Folder>
    {
        public override IList<Folder> Values
        {
            get { throw new System.NotImplementedException(); }
        }
    }

    public class FolderRequest :XeroRequest<Model.Folder>
    {
     }
}