using System.Collections.Generic;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.Exceptions;

namespace CoreTests.Integration.General
{
    [TestFixture]
    public class Errors : ApiWrapperTest
    {
        [Test]
        public void not_found()
        {
            Assert.Throws<NotFoundException>(() => Api.Invoices.Find("ThisIsNotThere"));
        }

        [Test]
        public void bad_query()
        {
            Assert.Throws<BadRequestException>(() => Api.Invoices.Where("Bob == Robert").Find());
        }

        [Test]
        public void validation_error()
        {
            Assert.Throws<ValidationException>(() => Api.Invoices.Create(new Invoice
            {
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        LineAmount = 101.01M
                    }
                }
            }));
        }
    }
}
