using System;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.TrackingCategories
{
    [TestFixture]
    public class AddTrackingOption : TrackingCategoriesTest
    {
        [Test]
        public void Can_add_tracking_options()
        {
            var category = Given_a_TrackingCategory();

            Api.TrackingCategories[category.Id].Add(new Option(){Id = Guid.NewGuid(),Name="Test"});

        }
    }
}
