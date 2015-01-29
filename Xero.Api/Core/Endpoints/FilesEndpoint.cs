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
using Xero.Api.Infrastructure.ThirdParty.ServiceStack.Text;

namespace Xero.Api.Core.Endpoints
{
    public class FilesEndpoint : XeroUpdateEndpoint<FilesEndpoint,Model.File,FilesRequest,FilesResponse>
    {
        
        internal FilesEndpoint(XeroHttpClient client)
            : base(client, "files.xro/1.0/Files")
        {
            
        }
        
        public Model.File this[Guid id]
        {
            get
            {
                var result = Find(id);
                return result; 
            }
        }
        
        public IList<Model.File> Find()
        {
            var response = HandleFilesResponse(Client
                .Client.Get("files.xro/1.0/Files","" ));

            return response.Items;
        }

        public Model.File Find(Guid fileId)
        {
            var response = HandleFilesResponse(Client
                .Client.Get("files.xro/1.0/Files", ""));

            return response.Items.SingleOrDefault(i=>i.Id == fileId) ;
        }

        public Model.File Rename(Guid id, string name)
        {
            var response = HandleFileResponse(Client
                .Client.Put("files.xro/1.0/Files/" + id, "{\"Name\":\"" + name + "\"}","application/json"));


            return response;
        }

        public Model.File Add(Guid folderId, Model.File file, byte[] data)
        {
           
            var response = HandleFileResponse(Client
                .Client
                .PostMultipartForm("files.xro/1.0/Files/"+ folderId, file.Mimetype,  file.Name, file.FileName, data));

            return response;
        }

        public Model.File Remove(Guid fileid)
        {
            var response = HandleFileResponse(Client
                .Client
                .Delete("files.xro/1.0/Files/"+fileid.ToString()));

            return response;
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