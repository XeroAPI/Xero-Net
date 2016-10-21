﻿using System.Configuration;

namespace Xero.Api.Example.Applications.PublicAsync
{
    public class Settings
    {
        public string Uri
        {
            get { return ConfigurationManager.AppSettings["BaseUrl"]; }
        }

        public string CallBackUri
        {
            get { return ConfigurationManager.AppSettings["CallbackUrl"]; }
        }

        public string SigningCertificatePath
        {
            get { return ConfigurationManager.AppSettings["SigningCertificate"]; }
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