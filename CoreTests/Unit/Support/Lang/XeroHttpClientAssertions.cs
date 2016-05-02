using NUnit.Framework;
using Xero.Api.Infrastructure.Http;

namespace CoreTests.Unit.Support.Lang
{
    internal static class XeroHttpClientAssertions
    {
        internal static void MustHaveBaseUri(this XeroHttpClient self, string expected)
        {
            Assert.AreEqual(expected, self.BaseUri);
        }
    }
}