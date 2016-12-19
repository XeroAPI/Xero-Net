using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Infrastructure.RateLimiter;
using Xero.Api.Serialization;

namespace Xero.Api.Example.Applications.Partner
{
    public class AustralianPayroll : Payroll.AustralianPayroll
    {
        private static readonly DefaultMapper Mapper = new DefaultMapper();
        private static readonly Settings ApplicationSettings = new Settings();

        public AustralianPayroll(ITokenStore store, IUser user, bool includeRateLimiter = false) :
            base(ApplicationSettings.Uri,
                new PartnerAuthenticator(
                    ApplicationSettings.Uri,
                    ApplicationSettings.AuthorizeUri,
                    ApplicationSettings.CallBackUri,
                    store,
                    ApplicationSettings.SigningCertificatePath,
                    ApplicationSettings.SigningCertificatePassword),
                new Consumer(
                    ApplicationSettings.Key,
                    ApplicationSettings.Secret),
                user,
                Mapper,
                Mapper,
                includeRateLimiter ? new RateLimiter() : null)
        {
        }
    }
}