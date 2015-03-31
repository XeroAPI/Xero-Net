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
    public class ArchiveTrackingCategory : TrackingCategoriesTest
    {
        [Test]
        public void Can_archieve_tracking_category()
        {
            var category = Given_a_TrackingCategory_with_Options();

            Given_approved_invoice_with_tracking_option(category);

            category.Status = TrackingCategoryStatus.Archived;

            var result = Api.Update(category);

            Assert.True(result.Status == TrackingCategoryStatus.Archived);

            Given_Invoice_is_voided();
            Given_Tracking_Category_is_deleted(category);
        }
    }
}
