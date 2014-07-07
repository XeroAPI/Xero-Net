using System;

namespace Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters
{
    internal class ParameterEncoding
    {
        internal string Escape(string what)
        {
            return Uri.EscapeDataString(what ?? "");
        }
    }
}