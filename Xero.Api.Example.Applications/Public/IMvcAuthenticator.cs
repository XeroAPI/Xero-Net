using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Example.Applications.Public
{
    public interface IMvcAuthenticator
    {
        string GetRequestTokenAuthorizeUrl(string userId);
        IToken RetrieveAndStoreAccessToken(string userId, string tokenKey, string verfier, string organisationShortCode);
    }
}