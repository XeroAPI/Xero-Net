using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.TrackingCategories
{
    public class TrackingCategoriesTest : ApiWrapperTest
    {
        public TrackingCategory Given_a_TrackingCategory()
        {
            return Api.Create(new TrackingCategory
            {
                Id = new Guid(),
                Name = "TheJoker " + Guid.NewGuid(),
                Status = TrackingCategoryStatus.Active
            });
        }


  
    }
}
