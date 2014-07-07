using System;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Infrastructure.OAuth
{
    public class Token : IToken
    {
        // For serialization
        public Token()
        {
        }

        public Token(string consumerKey, string consumerSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
        }

        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string TokenKey { get; set; }
        public string TokenSecret { get; set; }
        public DateTime? ExpiresAt { get; set; }

        public string Session { get; set; }
        public DateTime? SessionExpiresAt { get; set; }

        public string OrganisationId { get; set; }
        public string UserId { get; set; }

        public bool HasExpired
        {
            get
            {
                return ExpiresAt < DateTime.UtcNow;
            }
        }

        public bool HasSessionExpired
        {
            get
            {
                return SessionExpiresAt < DateTime.UtcNow;
            }
        }
    }
}