﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.ThirdParty.Dust;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters.Nonce;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters.Timestamp;
using Xero.Api.Infrastructure.ThirdParty.Dust.Http;

namespace Xero.Api.Infrastructure.OAuth.Signing
{
    public class RsaSha1Signer
    {
        public string CreateSignature(X509Certificate2 certificate, IToken token, Uri uri, string verb,
            string verifier = null, bool renewToken = false, string callback = null, IEnumerable<KeyValuePair<string, string>> additionalParameters = null)
        {
            var oAuthParameters = new OAuthParameters(
                new ConsumerKey(token.ConsumerKey),
                new TokenKey(token.TokenKey),
                "RSA-SHA1",
                new DefaultTimestampSequence(),
                new DefaultNonceSequence(),
                string.Empty,
                "1.0",
                verifier,
                token.Session,
                renewToken,
                callback,
                additionalParameters);

            var signatureBaseString =
                new SignatureBaseString(
                    new Request
                    {
                        Url = uri,
                        Verb = verb
                    },
                    oAuthParameters);

            var signature = new RsaSha1(certificate).Sign(signatureBaseString);

            oAuthParameters.SetSignature(signature);

            return new AuthorizationHeader(oAuthParameters, string.Empty, renewToken).Value;        
        }
    }
}