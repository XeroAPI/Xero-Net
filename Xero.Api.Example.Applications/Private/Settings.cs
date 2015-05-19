using System.Configuration;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Example.Applications.Private
{
    public class Settings
    {
        public string Uri
        {
            get { return ConfigurationManager.AppSettings["BaseUrl"]; }
        }

        public SigningCertificate SigningCertificate
        {
            get
            {
                return new SigningCertificate(
                    ConfigurationManager.AppSettings["SigningCertificate"], 
                    ConfigurationManager.AppSettings["SigningCertificatePassword"]);
            }
        }

        public IConsumer Consumer {
            get
            {
                return new Consumer(Key, Secret);
            }
        }

        public string Key
        {
            get { return ConfigurationManager.AppSettings["ConsumerKey"]; }
        }

        public string Secret
        {
            get { return ConfigurationManager.AppSettings["ConsumerSecret"]; }
        }
    }
}