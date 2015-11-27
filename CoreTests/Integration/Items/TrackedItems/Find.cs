﻿using NUnit.Framework;

namespace CoreTests.Integration.Items.TrackedItems
{
    public class Find : TrackedInventoryTest
    {
        [Test]
        public void Can_get_tracked_item_by_id()
        {
            Given_a_tracked_item();

            var trackedItem = Api.Items.Find(CreatedItem.Id);

            Assert.AreEqual(CreatedItem.Id, trackedItem.Id, "Expected the ID of the created item and retrieved item to be the same but weren't");
            Assert.True(trackedItem.IsTrackedAsInventory, "Expected the retrieved items IsTrackedAsInventory value to be true, but was false");
        }
    }
}
