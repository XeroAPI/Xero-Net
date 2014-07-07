using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Serialization;

namespace Xero.Api.Example.Applications.Private
{
    public class AustralianPayroll : Payroll.AustralianPayroll
    {
        private static readonly DefaultMapper Mapper = new DefaultMapper();
        private static readonly Settings ApplicationSettings = new Settings();

        public AustralianPayroll() :
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