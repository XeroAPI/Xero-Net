using System;
using System.Security.Cryptography;

namespace CoreTests
{
    public static class Random
    {
        public static string GetRandomString(int length)
        {
            var numArray = new byte[length];
            new RNGCryptoServiceProvider().GetBytes(numArray);
            return SanitiseBase64String(Convert.ToBase64String(numArray), length);
        }

        private static string SanitiseBase64String(string input, int maxLength)
        {
            input = input.Replace("-", "");
            input = input.Replace("=", "");
            input = input.Replace("/", "");
            input = input.Replace("+", "");
            input = input.Replace(" ", "");
            while (input.Length < maxLength)
                input = input + GetRandomString(maxLength);
            return input.Length <= maxLength ?
                input.ToUpper() :
                input.ToUpper().Substring(0, maxLength);
        }
    }
}
