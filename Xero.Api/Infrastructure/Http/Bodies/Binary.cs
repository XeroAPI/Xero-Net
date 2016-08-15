using System.Net;

namespace Xero.Api.Infrastructure.Http.Bodies
{
    internal static class Binary
    {
        internal static void Write(WebRequest request, byte[] bytes, string contentType)
        {
            request.ContentLength = bytes.Length;
            request.ContentType = contentType;

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}