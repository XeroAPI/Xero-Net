using System;
using Xero.Api.Core;
using Xero.Api.Example.Applications.Partner;
using Xero.Api.Example.Applications.Public;
using Xero.Api.Example.MVC.Stores;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Serialization;

namespace Xero.Api.Example.MVC.Helpers
{
    public class ApplicationSettings
    {
        public string BaseApiUrl { get; set; }
        public Consumer Consumer { get; set; }
        public object Authenticator { get; set; }
    }

    public static class XeroApiHelper
    {
        private static ApplicationSettings _applicationSettings;

        static XeroApiHelper()
        {
            // Refer to README.md for details
            var callbackUrl = "http://mywebsite.url/Home/Authorize";
            var memoryStore = new MemoryAccessTokenStore();
            var requestTokenStore = new MemoryRequestTokenStore();
            var baseApiUrl = "https://api.xero.com";
            var basePartnerApiUrl = "https://api-partner.network.xero.com";

            var signingCertificatePath = @"C:\Dev\your_public_privatekey.pfx";
            var signingCertificatePassword = "Your_signing_cert_password - leave empty if you didn't set one when creating the cert";
            var clientCertificatePath = @"C:\Dev\your_entrust_cert.p12";
            var clientCertificatePassword = "your_entrust_cert_password";

            var publicAppConsumerKey = "your-public-app-consumer-key";
            var publicAppConsumerSecret = "your-public-app-consumer-secret";
            var partnerConsumerKey = "your-partner-app-consumer-key";
            var partnerConsumerSecret = "your-partner-app-consumer-secret";

            // Public Application Settings
            var publicConsumer = new Consumer(publicAppConsumerKey, publicAppConsumerSecret);

            var publicAuthenticator = new PublicMvcAuthenticator(baseApiUrl, baseApiUrl, callbackUrl, memoryStore, 
                publicConsumer, requestTokenStore);

            var publicApplicationSettings = new ApplicationSettings
                {
                    BaseApiUrl = baseApiUrl,
                    Consumer = publicConsumer,
                    Authenticator = publicAuthenticator
                };

            // Partner Application Settings
            var partnerConsumer = new Consumer(partnerConsumerKey, partnerConsumerSecret);

            var partnerAuthenticator = new PartnerMvcAuthenticator(basePartnerApiUrl, baseApiUrl, callbackUrl,
                    memoryStore, signingCertificatePath, clientCertificatePath, clientCertificatePassword, 
                    partnerConsumer, requestTokenStore, signingCertificatePassword);

            var partnerApplicationSettings = new ApplicationSettings
            {
                BaseApiUrl = basePartnerApiUrl,
                Consumer = partnerConsumer,
                Authenticator = partnerAuthenticator
            };

            // Pick one
            // Choose what sort of application is appropriate. Comment out the above code (Partner Application Settings/Public Application Settings) that are not used.

            //_applicationSettings = publicApplicationSettings;
            _applicationSettings = partnerApplicationSettings;
        }

        public static ApiUser User()
        {
            return new ApiUser { Name = Environment.MachineName };    
        }

        public static IConsumer Consumer()
        {
            return _applicationSettings.Consumer;
        }

        public static IMvcAuthenticator MvcAuthenticator()
        {
            return (IMvcAuthenticator)_applicationSettings.Authenticator;
        }

        public static XeroCoreApi CoreApi()
        {
            if (_applicationSettings.Authenticator is ICertificateAuthenticator)
            {
                return new XeroCoreApi(_applicationSettings.BaseApiUrl, _applicationSettings.Authenticator as ICertificateAuthenticator,
                    _applicationSettings.Consumer, User(), new DefaultMapper(), new DefaultMapper());
            }

            if (_applicationSettings.Authenticator is IAuthenticator)
            {
                return new XeroCoreApi(_applicationSettings.BaseApiUrl, _applicationSettings.Authenticator as IAuthenticator,
                    _applicationSettings.Consumer, User(), new DefaultMapper(), new DefaultMapper());
            }
           
            return null;
        }
    }
}
