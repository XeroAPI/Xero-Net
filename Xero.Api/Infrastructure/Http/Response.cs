using System;
using System.IO;
using System.Net;

namespace Xero.Api.Infrastructure.Http
{
    internal class Response
    {
        internal Response(HttpWebResponse inner)
        {
            StatusCode = inner.StatusCode;
            ContentLength = (int) inner.ContentLength;
            ContentType = inner.ContentType;

            var stream = inner.GetResponseStream();
            if (stream != null)
            {
                Stream = new MemoryStream();
                stream.CopyTo(Stream);
                // rewind
                Stream.Seek(0, SeekOrigin.Begin);
            }            
        }

        public string Body
        {
            get
            {
                using (var rdr = new StreamReader(Stream))
                {
                    var result = rdr.ReadToEnd();

                    Stream.Seek(0, SeekOrigin.Begin);
                        
                    return result;
                }
            }
        }

        public Stream Stream { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }

        public int ContentLength { get; private set; }

        public string ContentType { get; private set; }
    }
}