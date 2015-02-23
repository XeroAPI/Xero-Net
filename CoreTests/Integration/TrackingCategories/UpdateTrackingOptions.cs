using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Endpoints;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.TrackingCategories
{
    [TestFixture]
    public class UpdateTrackingOption : TrackingCategoriesTest
    {
        [Test]
        public void Can_update_tracking_options()
        {
            var category = Given_a_TrackingCategory();

            var option = Given_a_tracking_option();

            Api.TrackingCategories[category.Id].Add(option);

            var result = Api.TrackingCategories[category.Id];

            Assert.True(result._trackingCat.Options.FirstOrDefault().Name == option.Name);
        }

    }
}
