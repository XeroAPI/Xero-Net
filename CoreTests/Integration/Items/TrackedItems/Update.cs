using NUnit.Framework;

namespace CoreTests.Integration.Items.TrackedItems
{
    public class Update : TrackedInventoryTest
    {
        [Test]
        public void Can_update_an_item_to_make_it_not_tracked_and_not_for_purchase()
        {
            Given_a_tracked_item();

            CreatedItem.PurchaseDescription = null;
            CreatedItem.PurchaseDetails = null;
            CreatedItem.InventoryAssetAccountCode = null;
            CreatedItem.IsPurchased = false;

            var updatedItem = Api.Items.Update(CreatedItem);

            Assert.AreEqual(updatedItem.Id, CreatedItem.Id, "Expected the item's ID to be the same after creating and updating but they were different.");
            Assert.IsFalse(updatedItem.IsTrackedAsInventory, "Expected the item's IsTrackedAsInventory value to be false but was true");
            Assert.IsFalse(updatedItem.IsPurchased.Value, "Expected the updated item's IsPurchased value to be false but was true.");
        }

        [Test]
        public void Can_update_an_item_to_make_it_not_tracked_and_not_for_sale()
        {
            Given_a_tracked_item();

            CreatedItem.Description = null;
            CreatedItem.SalesDetails = null;
            CreatedItem.InventoryAssetAccountCode = null;
            CreatedItem.IsSold = false;
            CreatedItem.PurchaseDetails.AccountCode = DirectCostsAccountCode;
            CreatedItem.PurchaseDetails.COGSAccountCode = null;

            var updatedItem = Api.Items.Update(CreatedItem);

            Assert.AreEqual(updatedItem.Id, CreatedItem.Id, "Expected the item's ID to be the same after creating and updating but they were different.");
            Assert.IsFalse(updatedItem.IsTrackedAsInventory, "Expected the item's IsTrackedAsInventory value to be false but was true");
            Assert.IsFalse(updatedItem.IsSold.Value, "Expected the updated item's IsPurchased value to be false but was true.");
        }

        [Test]
        public void Can_update_an_item_to_make_it_not_tracked_but_still_for_sale_and_purchase()
        {
            Given_a_tracked_item();

            CreatedItem.PurchaseDetails.COGSAccountCode = null;
            CreatedItem.InventoryAssetAccountCode = null;

            var updatedItem = Api.Items.Update(CreatedItem);

            Assert.AreEqual(updatedItem.Id, CreatedItem.Id, "Expected the item's ID to be the same after creating and updating but they were different.");
            Assert.IsFalse(updatedItem.IsTrackedAsInventory, "Expected the item's IsTrackedAsInventory value to be false but was true");
            Assert.IsTrue(updatedItem.IsSold.Value, "Expected the updated item's IsSold value to be true but was false.");
            Assert.IsTrue(updatedItem.IsPurchased.Value, "Expected the updated item's IsPurchased value to be true but was false.");
        }
    }
}
