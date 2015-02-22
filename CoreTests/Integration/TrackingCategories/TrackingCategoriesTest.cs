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

        public List<Option> Given_TrackingOptions()
        {
            List<Option> options = new List<Option>();

            options.Add(new Option()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString()
            });

            options.Add(new Option()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString()
            });

            return options;
        }

        public TrackingCategory Can_Add_TrackingOptions_to_Category(TrackingCategory category, List<Option> options )
        {
//            foreach (var option in options)
//            {
//                category.Options.Add(option);
//            }

            return Api.Update(category, options);
        }


//        public TrackingCategory Archieve_a_TrackingCategoy(TrackingCategory input)
//        {
//            input.Status = TrackingCategoryStatus.Archived;
//
//            return Api.Update(input);
//        }

    }
}
