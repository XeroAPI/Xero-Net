using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Serialization;

namespace Xero.Api.Example.Applications.Private
{
    public class AmericanPayroll : Payroll.AmericanPayroll
    {
        private static readonly DefaultMapper Mapper = new DefaultMapper();
        private static readonly Settings ApplicationSettings = new Settings();

        public AmericanPayroll() :
            base(ApplicationSettings.Uri,
                new PrivateAuthenticator(ApplicationSettings.SigningCertificatePath),
                new Consumer(ApplicationSettings.Key, ApplicationSettings.Secret),
                null,
                Mapper,
                Mapper)
        {
        }
    }
}