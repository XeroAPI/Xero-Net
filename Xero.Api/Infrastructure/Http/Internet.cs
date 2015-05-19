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
                return new Response((HttpWebResponse)we.Response);
            }
        }
    }
}