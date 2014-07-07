using System;
using System.Security.Cryptography;
using System.Text;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters;

namespace Xero.Api.Infrastructure.ThirdParty.Dust
{
    public class HmacSha1
    {
        public string Sign(string signatureBaseString, string consumerSecret, string tokenSecret)
        {
            string key = Key(consumerSecret, tokenSecret);

            var signature = SignCore(signatureBaseString, key);

            return Base64Encode(signature);
        }

        private string Key(string consumerSecret, string tokenSecret)
        {
            return string.Format("{0}&{1}", Escape(consumerSecret), Escape(tokenSecret));
        }

        private string Escape(string what)
        {
            return new ParameterEncoding().Escape(what);
        }

        private string Base64Encode(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        private byte[] SignCore(string text, string key)
        {
            var encoding = Encoding.ASCII;

            byte[] keyBytes = encoding.GetBytes(key);
            byte[] textBytes = encoding.GetBytes(text);

            using (var hmac = new HMACSHA1(keyBytes))
            {
                return hmac.ComputeHash(textBytes);
            }
        }
    }
}