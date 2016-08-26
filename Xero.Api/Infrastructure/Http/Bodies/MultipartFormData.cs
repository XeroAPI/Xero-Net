using System;
using System.Net;
using System.Text;

namespace Xero.Api.Infrastructure.Http.Bodies
{
    internal class MultipartFormData
    {
        internal static void Write(HttpWebRequest request, byte[] bytes, string contentType, string name, string filename)
        {
            var boundary = Guid.NewGuid();

            byte[] header = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=" + name + "; FileName=" + filename + " \r\nContent-Type: " + contentType + "\r\n\r\n");
            byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.KeepAlive = false;

            var contentLength = bytes.Length + header.Length + trailer.Length;

            request.ContentLength = contentLength;

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(header, 0, header.Length);
                dataStream.Write(bytes, 0, bytes.Length);
                dataStream.Write(trailer, 0, trailer.Length);
                dataStream.Flush();
                dataStream.Close();
            }
        }
    }
}