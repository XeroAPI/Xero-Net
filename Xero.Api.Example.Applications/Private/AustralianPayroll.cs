using Xero.Api.Infrastructure.RateLimiter;
using Xero.Api.Serialization;

namespace Xero.Api.Example.Applications.Private
{
    public class AustralianPayroll : Payroll.AustralianPayroll
    {
        private static readonly DefaultMapper Mapper = new DefaultMapper();
        private static readonly Settings ApplicationSettings = new Settings();

        public AustralianPayroll(bool includeRateLimiter = false) :
            base(ApplicationSettings.Uri,
                new PrivateAuthenticator(ApplicationSettings.SigningCertificate, ApplicationSettings.Consumer),
                ApplicationSettings.Consumer,
                null,
                Mapper,
                Mapper,
                includeRateLimiter ? new RateLimiter() : null)
        {
        }
    }
}