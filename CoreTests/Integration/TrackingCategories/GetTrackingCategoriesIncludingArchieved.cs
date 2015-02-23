using System;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using System.Collections.Generic;

namespace CoreTests.Integration.TrackingCategories
{
    [TestFixture]
    public class GetTrackingCategoriesIncludingArchieved : TrackingCategoriesTest
    {
        [Test]
        public void Can_get_Tracking_Category_including_archieved()
        {
            var category1 = Given_a_TrackingCategory_with_Options();

            category1.Status = TrackingCategoryStatus.Archived;

            Api.TrackingCategories.Update(category1);


//            List<TrackingCategory> result = Api.TrackingCategories.GetAll();

//            Assert.IsTrue(result.First().Name == category1.Name);
//            Assert.IsTrue(result.ElementAt(1).Name == category2.Name);
        }
    }
}
