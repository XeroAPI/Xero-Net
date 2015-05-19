using System.Configuration;

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