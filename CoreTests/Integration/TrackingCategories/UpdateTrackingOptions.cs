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
        public void Can_update_tracking_options_name()
        {
            var category = Given_a_TrackingCategory();

            var option = Given_a_tracking_option();

            var option1 = Api.TrackingCategories[category.Id].Add(option).FirstOrDefault();
            
            option1.Name = "New Name";

            var result = Api.TrackingCategories[category.Id].UpdateOption(option1);

            Assert.True(result.Name == "New Name");

            Given_Tracking_Category_is_deleted(category);
        }

        [Test]
        public void Can_update_tracking_options_status()
        {
            var category = Given_a_TrackingCategory_with_Options();

            Given_approved_invoice_with_tracking_option(category);

            category.Options.FirstOrDefault().Status = TrackingOptionStatus.Archived;

            var result = Api.TrackingCategories[category.Id].UpdateOption(category.Options.FirstOrDefault());

            Assert.True(result.Status == TrackingOptionStatus.Archived);

            Given_Invoice_is_voided();
            Given_Tracking_Category_is_deleted(category);

        }
    }
}
