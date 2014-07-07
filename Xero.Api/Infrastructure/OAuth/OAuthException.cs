using System;

namespace Xero.Api.Infrastructure.OAuth
{
    internal class OAuthException : Exception
    {
        public OAuthException(string message) : base (message)
        {
        }
    }
}