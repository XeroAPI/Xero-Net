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
        public void Can_add_Tracking_options()
        {
            var category = Given_a_TrackingCategory();

            var trackingOptions = Given_TrackingOptions();

            var result = Can_Add_TrackingOptions_to_Category(category, trackingOptions);

            Assert.IsTrue(result.Name.StartsWith("TheJoker"));
            Assert.IsTrue(result.Options.First().Name == trackingOptions.First().Name);
            Assert.IsTrue(result.Options.ElementAt(1).Id == trackingOptions.ElementAt(1).Id);
        }
    }
}
