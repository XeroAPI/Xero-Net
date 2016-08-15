using System.Net;

namespace Xero.Api.Infrastructure.Http
{
    internal static class Internet
    {
        internal static Response Exec(WebRequest request)
        {
            try
            {
                return new Response((HttpWebResponse)request.GetResponse());
            }
            catch (WebException we)
            {
                if (we.Status.Equals(WebExceptionStatus.ProtocolError))
                    return new Response((HttpWebResponse)we.Response);

                throw;
            }
        }
    }
}