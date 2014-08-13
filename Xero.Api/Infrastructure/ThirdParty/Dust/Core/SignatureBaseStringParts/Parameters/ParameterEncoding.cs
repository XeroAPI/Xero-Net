using System;
using Xero.Api.Infrastructure.ThirdParty.HttpUtility;

namespace Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters
{
    internal class ParameterEncoding
    {
        internal string Escape(string what)
        {
            return UrlEncoder.UrlEncode(what ?? string.Empty);
        }
    }
}