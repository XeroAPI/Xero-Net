using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero.Api.Infrastructure.Http
{
    partial class Response
    {
        private Response(System.Net.Http.HttpResponseMessage inner, Stream stream)
        {
            StatusCode = inner.StatusCode;
            ContentLength = (int)inner.Content.Headers.ContentLength;
            ContentType = inner.Content.Headers.ContentType.MediaType;
            Stream = stream;
        }

        internal static async Task<Response> CreateResponseAsync(System.Net.Http.HttpResponseMessage inner)
        {
            MemoryStream targetStream = null;
            var stream = await inner.Content.ReadAsStreamAsync();
            if (stream != null)
            {
                targetStream  = new MemoryStream();
                stream.CopyTo(targetStream);
                // rewind
                targetStream.Seek(0, SeekOrigin.Begin);
            }

            return new Response(inner, targetStream);
        }
    }
}
