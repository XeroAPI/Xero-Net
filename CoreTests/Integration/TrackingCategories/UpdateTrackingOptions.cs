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
            Given_a_TrackingCategory_with_Option();

            Given_first_Option_Name_change();

            Given_Tracking_Category_is_deleted();
        }

        [Test]
        public void Can_update_tracking_options_status()
        {
            Given_a_TrackingCategory_with_Options();

            Given_approved_invoice_with_tracking_option();

            Given_first_Option_is_Archived();

            Given_Invoice_is_voided();
            Given_Tracking_Category_is_deleted();

        }
    }
}
