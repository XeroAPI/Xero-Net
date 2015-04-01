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
    public class AddTrackingOption : TrackingCategoriesTest
    {
        [Test]
        public void Can_add_tracking_option()
        {
            Given_a_TrackingCategory_with_Option();

            Then_Category_Has_Option();

            Given_Tracking_Category_is_deleted();
        }

        [Test]
        public void Can_add_tracking_options()
        {
            Given_a_TrackingCategory_with_Options();

            Then_Category_Has_Options();

            Given_Tracking_Category_is_deleted();
        }
    }
}
