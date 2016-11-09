using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAsyncCertificateAuthenticator : IAsyncAuthenticator
    {
        X509Certificate Certificate
        {
            get;
        }
    }
}
