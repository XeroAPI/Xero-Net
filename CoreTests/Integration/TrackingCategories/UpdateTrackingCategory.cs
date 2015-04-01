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
    public class UpdateTrackingCategory : TrackingCategoriesTest
    {
        [Test]
        public void Can_update_tracking_category_name()
        {
            Given_a_TrackingCategory();

            Given_name_change_to_categorie();

            Given_Tracking_Category_is_deleted();
        }

        [Test]
        public void Can_update_tracking_category_with_Options_name()
        {
            Given_a_TrackingCategory_with_Options();

            Given_name_change_to_categorie();

            Given_Tracking_Category_is_deleted();
        }
    }
}
