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
        public TrackingCategory Given_a_TrackingCategory_with_Options()
        {
            var trackingCategory = Given_a_TrackingCategory();

            var option1 = Given_a_tracking_option();
            var option2 = Given_a_tracking_option();

            Api.TrackingCategories[trackingCategory.Id].Add(option1);
            var result = Api.TrackingCategories[trackingCategory.Id].Add(option2);

            return result;
        }

        public TrackingCategory Given_a_TrackingCategory()
        {
            var trackingCategory = Api.TrackingCategories.Add(new TrackingCategory
            {
                Id = new Guid(),
                Name = "TheJoker " + Guid.NewGuid(),
                Status = TrackingCategoryStatus.Active
            });

            return trackingCategory;
        }

        public Option Given_a_tracking_option()
        {
            return new Option()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString()
            };
        }

        public List<Option> Given_a_tracking_options()
        {
            List<Option> options = new List<Option>();

            options.Add(Given_a_tracking_option());
            options.Add(Given_a_tracking_option());

            return options;
        }
    }
}
