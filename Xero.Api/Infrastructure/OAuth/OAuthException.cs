using System;

namespace Xero.Api.Infrastructure.OAuth
{
    public class OAuthException : Exception
    {
        public OAuthException(string message) : base (message)
        {
        }
    }
}