using System.Collections.Generic;
using System.Linq;

namespace Xero.Api.Core.Endpoints.Internal
{
    internal static class Url
    {
        internal static string From(string basePath, IEnumerable<object> parts)
        {
            return string.Join("/", new[] { basePath }.Concat(parts));
        }

        internal static string From(IEnumerable<object> parts)
        {
            return string.Join("/", parts.Select(it => it.ToString()).ToArray());
        }
    }
}