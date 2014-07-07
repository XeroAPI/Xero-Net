using System;
using System.Collections.Specialized;

namespace Xero.Api.Common
{
    public static class Extensions
    {
        public static void Add(this NameValueCollection collection, string name, Guid? value)
        {
            if (value.HasValue)
            {
                collection.Add(name, value.Value.ToString("D"));
            }
        }

        public static void Add(this NameValueCollection collection, string name, int? value)
        {
            if (value.HasValue)
            {
                collection.Add(name, value.Value.ToString("D"));
            }
        }

        public static void Add(this NameValueCollection collection, string name, bool? value)
        {
            if (value.HasValue)
            {
                collection.Add(name, value.Value.ToString().ToLower());
            }
        }
    }
}
