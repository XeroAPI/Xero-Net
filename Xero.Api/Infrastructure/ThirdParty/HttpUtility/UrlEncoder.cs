using System;
using System.Text;

namespace Xero.Api.Infrastructure.ThirdParty.HttpUtility
{
    public static class UrlEncoder
    {
        const string UnreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        public static string UrlEncode(string value)
        {
            if (value == null) return null;

            var result = new StringBuilder();

            foreach (char symbol in value)
            {
                if (UnreservedChars.IndexOf(symbol) != -1)
                {
                    // Characters in the unreserved character set MUST NOT be encoded.
                    result.Append(symbol);
                }
                else
                {
                    // Text names and values MUST be encoded as UTF-8 octets before percent-encoding them
                    byte[] utf8Octets = Encoding.UTF8.GetBytes(new[] { symbol });

                    foreach (byte utf8Octet in utf8Octets)
                    {
                        // Second, the each octet should be %nn encoded
                        result.Append('%' + String.Format("{0:X2}", (int)utf8Octet));
                    }
                }
            }

            return result.ToString();
        }
    }
}