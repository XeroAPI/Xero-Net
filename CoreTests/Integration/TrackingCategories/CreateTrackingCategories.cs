using System;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.TrackingCategories
{
    [TestFixture]
    public class CreateTrackingCategories : TrackingCategoriesTest
    {
        [Test]
        public void Can_create_a_Tracking_Category()
        {
            Given_a_TrackingCategory();

            Given_Tracking_Category_is_deleted();
        }
    }
}
