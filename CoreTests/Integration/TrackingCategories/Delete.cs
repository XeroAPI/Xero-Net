using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model.Status;
using Xero.Api.Infrastructure.ThirdParty.ServiceStack.Text;

namespace CoreTests.Integration.TrackingCategories
{
    [TestFixture]
    public class Delete : TrackingCategoriesTest
    {
        [Test]
        public void can_delete_a_Tracking_Category()
        {
            var category = Given_a_TrackingCategory();

            Assert.IsTrue(category.Name.StartsWith("TheJoker"));
            
            Assert.IsTrue(category.Status == TrackingCategoryStatus.Active);

            category = Given_Tracking_Category_is_deleted(category);

            Assert.IsTrue(category.Status == TrackingCategoryStatus.Deleted);        
        }
        
        [Test]
        public void can_delete_a_Tracking_Category_Option()
        {
            var category = Given_a_TrackingCategory_with_Options();

            var option = Given_Tracking_CategoryOption_is_deleted(category, category.Options.FirstOrDefault());

            Assert.IsTrue(option.Status == TrackingOptionStatus.Deleted);

            Given_Tracking_Category_is_deleted(category);
        }

    }
}
