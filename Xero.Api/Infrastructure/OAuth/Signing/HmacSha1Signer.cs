using System;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.ThirdParty.Dust;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters.Nonce;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters.Timestamp;
using Xero.Api.Infrastructure.ThirdParty.Dust.Http;

namespace Xero.Api.Infrastructure.OAuth.Signing
{
    public class HmacSha1Signer
    {
        public string CreateSignature(IToken token, Uri uri, string verb, string verifier = null, string callback = null)
        {
            var oAuthParameters = new OAuthParameters(
                new ConsumerKey(token.ConsumerKey),
                new TokenKey(token.TokenKey),
                "HMAC-SHA1",
                new DefaultTimestampSequence(),
                new DefaultNonceSequence(),
                string.Empty,
                "1.0",
                verifier,
                token.Session, false, callback);

            var signatureBaseString =
                new SignatureBaseString(
                    new Request
                    {
                        Url = uri,
                        Verb = verb
                    },
                    oAuthParameters);

            var signature = new HmacSha1().Sign(signatureBaseString, token.ConsumerSecret, token.TokenSecret);

            oAuthParameters.SetSignature(signature);

            return new AuthorizationHeader(oAuthParameters, string.Empty).Value;
        }
    }
}
