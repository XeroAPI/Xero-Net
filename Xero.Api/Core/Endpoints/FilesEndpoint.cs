using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Net;
using Xero.Api.Core.Endpoints.Base;
using Xero.Api.Core.Model;
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


        public Model.File this[Guid id]
        {
            get { return Find(id); }
        }


       

        public FilesEndpoint Page(int page)
        {
            AddParameter("page", page);
            return this;
        }
        
        public IList<Model.File> Find()
        {
            var response = HandleFileResponse(Client
                .Client.Get("files.xro/1.0/Files","" ));

            return response.Items;
        }

        public Model.File Find(Guid fileId)
        {
            var response = HandleFileResponse(Client
                .Client.Get("files.xro/1.0/Files", ""));

            return response.Items.SingleOrDefault(i=>i.Id == fileId) ;
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

        
      

       

      

        public FilesResponse Add(Guid folderId,string contentType,Model.File file, byte[] data)
        {
           
            var response = HandleFileResponse(Client
                .Client
                .PostMultipartForm("files.xro/1.0/Files", folderId,contentType,  file.Name, file.Name, data));

            return response;
        }

        public FilesResponse Remove(Guid fileid)
        {
            var response = HandleFileResponse(Client
                .Client
                .Delete("files.xro/1.0/Files/"+fileid.ToString()));

            return response;
        }


        private FilePageResponse HandleFilePageResponse(Infrastructure.Http.Response response)
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

    }
}