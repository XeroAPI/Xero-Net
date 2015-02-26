using System;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using System.Collections.Generic;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.TrackingCategories
{
    [TestFixture]
    public class GetTrackingCategoriesIncludingArchieved : TrackingCategoriesTest
    {
        [Test]
        public void Can_get_Tracking_Category_including_archieved()
        {
            var category = Given_a_TrackingCategory_with_Options();

            Given_a_invoice_with_tracking_option_assigned_that_is_APPROVED(category);

            category.Status = TrackingCategoryStatus.Archived;

            Api.Update(category);

            var api = Api.TrackingCategories.IncludeArchived(true);

            List<TrackingCategory> result = api.GetAll();

            var actualTracking = result.SingleOrDefault(i => i.Id == category.Id);

            Assert.IsTrue(actualTracking != null);
        }
    }
}
