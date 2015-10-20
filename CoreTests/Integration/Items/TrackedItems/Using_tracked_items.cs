using System;
using NUnit.Framework;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.Items.TrackedItems
{
    public class Using_tracked_items : TrackedInventoryTest
    {
        //Purchase inventory like this
        [Test]
        public void Purchase_some_inventory_with_an_ACCPAY_invoice()
        {
            Given_a_tracked_item();

            Then_the_quantity_of_the_tracked_item_is_zero(CreatedItem);

            Given_an_ACCPAY_invoice_using_the_item_with_code(CreatedItem.Code);

            var item = Api.Items.Find(CreatedItem.Id);

            Then_the_quantity_of_the_tracked_item_is_more_than_zero(item);

        }

        //Sell inventory like this
        [Test]
        public void Sell_inventory_with_an_ACCREC_invoice()
        {
            Given_a_tracked_item();

            Given_a_tracked_item();

            Then_the_quantity_of_the_tracked_item_is_zero(CreatedItem);

            Given_an_ACCPAY_invoice_using_the_item_with_code(CreatedItem.Code);

            var item = Api.Items.Find(CreatedItem.Id);

            Then_the_quantity_of_the_tracked_item_is_more_than_zero(item);

            Given_an_ACCREC_invoice_using_the_item_with_code(item.Code);

            item = Api.Items.Find(item.Id);

            Then_the_quantity_of_the_tracked_item_is_zero(item);
        }

        //Make 'increase' adjustments like this
        [Test]
        public void Creating_a_zero_total_ACCPAY_invoice_increases_a_tracked_items_quantity_as_an_adjustment()
        {
            Given_a_tracked_item();

            Then_the_quantity_of_the_tracked_item_is_zero(CreatedItem);

            Given_a_zero_total_ACCPAY_invoice_using_the_item_with_code(CreatedItem.Code);

            var item = Api.Items.Find(CreatedItem.Id);
            Then_the_quantity_of_the_tracked_item_is_more_than_zero(item);
        }

        //Make 'decrease' adjustments like this
        [Test]
        public void Creating_a_zero_total_ACCREC_invoice_decreases_a_tracked_items_quantity()
        {
            Given_a_tracked_item();

            Then_the_quantity_of_the_tracked_item_is_zero(CreatedItem);

            Given_a_zero_total_ACCPAY_invoice_using_the_item_with_code(CreatedItem.Code);

            var item = Api.Items.Find(CreatedItem.Id);
            Then_the_quantity_of_the_tracked_item_is_more_than_zero(item);
 
            Given_a_zero_total_ACCREC_invoice_using_the_item_with_code(CreatedItem.Code);

            item = Api.Items.Find(CreatedItem.Id);

            Then_the_quantity_of_the_tracked_item_is_zero(item);
        }


        //Find quantity and cost details of an item like this
        [Test]
        public void Finding_a_tracked_item_gives_you_quantity_on_hand_and_total_cost_pool()
        {
            //Create a tracked item with no quantity, and therefore no total cost pool
            Given_a_tracked_item();

            var item = Api.Items.Find(CreatedItem.Id);

            var quantity = item.QuantityOnHand;
            Assert.True(quantity == 0, "Expected the quanity on hand of a new inventory item to be 0");

            var totalCostPool = item.TotalCostPool;
            Assert.True(totalCostPool == 0, "Expected the total cost pool of a new inventory item to be 0");

        }

        private void Then_the_quantity_of_the_tracked_item_is_zero(Item item)
        {
            Assert.True(CreatedItem.QuantityOnHand == 0);
        }

        private void Then_the_quantity_of_the_tracked_item_is_more_than_zero(Item item)
        {
            Assert.True(item.QuantityOnHand > 0);
        }
    }
}
