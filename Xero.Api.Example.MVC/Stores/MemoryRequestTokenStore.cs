using System.Collections.Concurrent;
using System.Collections.Generic;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Example.MVC.Stores
{
    public class MemoryRequestTokenStore : ITokenStore
    {
        private static readonly IDictionary<string, IToken> _tokens = new ConcurrentDictionary<string, IToken>();

        public IToken Find(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return null;

            IToken token;

            _tokens.TryGetValue(userId, out token);
            return token;
        }

        public void Add(IToken token)
        {
            _tokens[token.UserId] = token;
        }

        public void Delete(IToken token)
        {
            if (_tokens.ContainsKey(token.UserId))
            {
                _tokens.Remove(token.UserId);
            }
        }
    }

    

    //public class PartnerMvcAuthenticator : PartnerAuthenticator, IMvcAuthenticator
    //{
    //    private readonly IConsumer _consumer;
    //    private readonly ITokenStore _requestTokenStore;

    //    public PartnerMvcAuthenticator(string baseUri, string authorizeUri, string callBackUri, ITokenStore store, string signingCertificatePath,
    //        string certificatePath, string password, IConsumer consumer)
    //        : base(baseUri, authorizeUri, callBackUri, store, signingCertificatePath, certificatePath, password)
    //    {
    //        _consumer = consumer;
    //        _requestTokenStore = new MemoryRequestTokenStore();
    //    }

    //    protected override IToken GetToken(IConsumer consumer)
    //    {
    //        return base.GetToken(consumer);
    //    }

    //    public string GetRequestTokenAuthorizeUrl(string userId)
    //    {
    //        var requestToken = GetRequestToken(_consumer);
    //        requestToken.UserId = userId;

    //        var existingToken = _requestTokenStore.Find(userId);
    //        if (existingToken != null)
    //            _requestTokenStore.Delete(requestToken);

    //        _requestTokenStore.Add(requestToken);

    //        return GetAuthorizeUrl(requestToken);
    //    }

    //    public IToken RetrieveAndStoreAccessToken(string userId, string tokenKey, string verfier, string organisationShortCode)
    //    {
    //        var existingAccessToken = Store.Find(userId);
    //        if (existingAccessToken != null)
    //            return existingAccessToken;

    //        var requestToken = _requestTokenStore.Find(userId);
    //        if (requestToken == null)
    //            throw new ApplicationException("Failed to look up request token for user");

    //        _requestTokenStore.Delete(requestToken);

    //        if (requestToken.TokenKey != tokenKey)
    //            throw new ApplicationException("Request token key does not match");

    //        var accessToken = Tokens.GetAccessToken(requestToken,
    //            GetAuthorization(requestToken, "POST", Tokens.AccessUri, null, verfier));

    //        accessToken.UserId = userId;

    //        Store.Delete(accessToken);
    //        Store.Add(accessToken);

    //        return accessToken;
    //    }
    //}

//    public class PublicMvcAuthenticator : PublicAuthenticator, IMvcAuthenticator
//    {
//        private readonly IConsumer _consumer;
//        private readonly ITokenStore _requestTokenStore;
//
//        public PublicMvcAuthenticator(string baseUri, string tokenUri, string callBackUrl, ITokenStore store, IConsumer consumer) 
//            : base(baseUri, tokenUri, callBackUrl, store)
//        {
//            _consumer = consumer;
//            _requestTokenStore = new MemoryRequestTokenStore();
//        }
//
//        protected override IToken GetToken(IConsumer consumer)
//        {
//            return base.GetToken(consumer);
//        }
//
//        public string GetRequestTokenAuthorizeUrl(string userId)
//        {
//            var requestToken = GetRequestToken(_consumer);
//            requestToken.UserId = userId;
//
//            var existingToken = _requestTokenStore.Find(userId);
//            if (existingToken != null)
//                _requestTokenStore.Delete(requestToken);
//            
//            _requestTokenStore.Add(requestToken);
//
//            return GetAuthorizeUrl(requestToken);
//        }
//
//        public IToken RetrieveAndStoreAccessToken(string userId, string tokenKey, string verfier, string organisationShortCode)
//        {
//            var existingAccessToken = Store.Find(userId);
//            if (existingAccessToken != null)
//                return existingAccessToken;
//            
//            var requestToken = _requestTokenStore.Find(userId);
//            if (requestToken == null)
//                throw new ApplicationException("Failed to look up request token for user");
//
//            _requestTokenStore.Delete(requestToken);
//
//            if (requestToken.TokenKey != tokenKey)
//                throw new ApplicationException("Request token key does not match");
//
//            var accessToken = Tokens.GetAccessToken(requestToken,
//                GetAuthorization(requestToken, "POST", Tokens.AccessUri, null, verfier));
//
//            accessToken.UserId = userId;
//
//            Store.Delete(accessToken);
//            Store.Add(accessToken);
//
//            return accessToken;
//        }
//    }
}