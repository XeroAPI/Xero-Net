using System;
using CoreTests.Unit.Support;
using NUnit.Framework;

namespace CoreTests.Unit.BaseUrlConfiguration
{
    [TestFixture]
    public class BaseUrlConfiguration
    {
        [Test]
        public void both_constructors_behave_the_same()
        {
            var constructorOne = new SampleXeroApi("https://api.xero.com", new BlankCertificateAuthenticator(), null, null, null, null, null);
            var constructorTwo = new SampleXeroApi("https://api.xero.com", new BlankAuthenticator(), null, null, null, null, null);

            Assert.AreEqual("https://api.xero.com/api.xro/2.0", constructorOne.BaseUri);
            Assert.AreEqual("https://api.xero.com/api.xro/2.0", constructorTwo.BaseUri);
        }

        [Test]
        public void examples()
        {
            Check(
                Map("https://api.xero.com"                  , "https://api.xero.com/api.xro/2.0"),
                Map(" https://api.xero.com "                , "https://api.xero.com/api.xro/2.0"),
                Map("HTTPS://API.XERO.COM"                  , "https://api.xero.com/api.xro/2.0"),
                Map("https://api-partner.network.xero.com"  , "https://api-partner.network.xero.com/api.xro/2.0"),
                Map("https://xxx-anything-else-xxx/1.0"     , "https://xxx-anything-else-xxx/1.0"),
                Map("https://api.xero.com/"                 , "https://api.xero.com/api.xro/2.0"),
                Map("https://api-partner.network.xero.com/" , "https://api-partner.network.xero.com/api.xro/2.0")
            );
        }

        [Test]
        public void exception_examples()
        {
            CheckError(null);
            CheckError(" ");
            CheckError("xxx-not-a-url-xxx");
        }

        private void CheckError(string what)
        {
            Assert.Throws<ArgumentException>(()
                => new SampleXeroApi(what, new BlankCertificateAuthenticator(), null, null, null, null, null));
        }

        private static Tuple<string, string> Map(string @from, string to)
        {
            return new Tuple<string, string>(@from, to);
        }

        private void Check(params Tuple<string,string>[] checks)
        {
            foreach (var check in checks)
            {
                var actual = new SampleXeroApi(check.Item1, new BlankCertificateAuthenticator(), null, null, null, null, null);

                Assert.AreEqual(check.Item2, actual.BaseUri);
            }
        }
    }
}
