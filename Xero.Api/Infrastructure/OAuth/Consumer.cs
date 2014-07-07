using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Infrastructure.OAuth
{
    public class Consumer : IConsumer
    {
        // For serialization
        public Consumer()
        {
        }

        public Consumer(string consumerKey, string consumerSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
        }

        public string ConsumerKey { get; internal set; }
        public string ConsumerSecret { get; internal set; }        
    }
}
