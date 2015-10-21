using Xero.Api.Core;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Infrastructure.RateLimiter;
using Xero.Api.Serialization;

namespace Xero.Api.Example.Applications.Partner
{
    public class Core : XeroCoreApi
    {
        private static readonly DefaultMapper Mapper = new DefaultMapper();
        private static readonly Settings ApplicationSettings = new Settings();

        public Core(ITokenStore store, IUser user, bool includeRateLimiter = false) :
            base(ApplicationSettings.Uri,
                new PartnerAuthenticator(
                    ApplicationSettings.Uri,
                    ApplicationSettings.AuthorizeUri,
                    ApplicationSettings.CallBackUri,
                    store,
                    ApplicationSettings.SigningCertificatePath,
                    ApplicationSettings.ParterCertificatePath,
                    ApplicationSettings.ParterCertificatePassword),
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
