using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Serialization;

namespace Xero.Api.Example.Applications.Public
{
    public class AmericanPayroll : Payroll.AmericanPayroll
    {
        private static readonly DefaultMapper Mapper = new DefaultMapper();
        private static readonly Settings ApplicationSettings = new Settings();

        public AmericanPayroll(ITokenStore store, IUser user) :
            base(ApplicationSettings.Uri,
                new PublicAuthenticator(
                    ApplicationSettings.Uri,
                    ApplicationSettings.Uri,
                    ApplicationSettings.CallBackUri,
                    store),
                new Consumer(
                    ApplicationSettings.Key,
                    ApplicationSettings.Secret),
                user,
                Mapper,
                Mapper)
        {
        }
    }
}