using System;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Items.TrackedItems
{
    public class Update : ApiWrapperTest
    {

        private Item _createdItem;
        private string _inventoryAccountCode;
        private string _expenseAccountCode;
        private string _revenueAccountCode;

        [Test]
        public void Can_update_an_item_to_make_it_not_tracked_and_not_for_purchase()
        {
            Given_a_tracked_item();

            _createdItem.PurchaseDescription = null;
            _createdItem.PurchaseDetails = null;
            _createdItem.InventoryAssetAccountCode = null;
            _createdItem.IsPurchased = false;

            var updatedItem = Api.Items.Update(_createdItem);

            Assert.AreEqual(updatedItem.Id, _createdItem.Id, "Expected the item's ID to be the same after creating and updating but they were different.");
            Assert.IsFalse(updatedItem.IsTrackedAsInventory, "Expected the item's IsTrackedAsInventory value to be false but was true");
            Assert.IsFalse(updatedItem.IsPurchased.Value, "Expected the updated item's IsPurchased value to be false but was true.");
        }

        [Test]
        public void Can_update_an_item_to_make_it_not_tracked_and_not_for_sale()
        {
            Given_a_tracked_item();

            _createdItem.Description = null;
            _createdItem.SalesDetails = null;
            _createdItem.InventoryAssetAccountCode = null;
            _createdItem.IsSold = false;
            _createdItem.PurchaseDetails.AccountCode = _expenseAccountCode;
            _createdItem.PurchaseDetails.COGSAccountCode = null;

            var updatedItem = Api.Items.Update(_createdItem);

            Assert.AreEqual(updatedItem.Id, _createdItem.Id, "Expected the item's ID to be the same after creating and updating but they were different.");
            Assert.IsFalse(updatedItem.IsTrackedAsInventory, "Expected the item's IsTrackedAsInventory value to be false but was true");
            Assert.IsFalse(updatedItem.IsSold.Value, "Expected the updated item's IsPurchased value to be false but was true.");
        }

        [Test]
        public void Can_update_an_item_to_make_it_not_tracked()
        {
            Given_a_tracked_item();

            _createdItem.Description = null;
            _createdItem.SalesDetails = null;
            _createdItem.PurchaseDetails = null;
            _createdItem.IsSold = false;
            _createdItem.InventoryAssetAccountCode = null;
            _createdItem.IsPurchased = false;
            _createdItem.PurchaseDescription = null;

            var updatedItem = Api.Items.Update(_createdItem);

            Assert.AreEqual(updatedItem.Id, _createdItem.Id, "Expected the item's ID to be the same after creating and updating but they were different.");
            Assert.IsFalse(updatedItem.IsTrackedAsInventory, "Expected the item's IsTrackedAsInventory value to be false but was true");
            Assert.IsFalse(updatedItem.IsSold.Value, "Expected the updated item's IsSold value to be false but was true.");
            Assert.IsFalse(updatedItem.IsPurchased.Value, "Expected the updated item's IsSold value to be false but was true.");
        }

        public void Given_a_tracked_item()
        {
            Given_an_inventory_account();
            Given_a_direct_cost_account();
            Given_a_revenue_account();

            var code = "Tracked Item " + Random.GetRandomString(10);

            var item = Api.Items.Create(new Item
            {
                Code = code,
                Description = "Sell me",
                PurchaseDescription = "Purchase me",
                PurchaseDetails = new PurchaseDetails
                {
                    UnitPrice = 75.5555m,
                    TaxType = "INPUT2",
                    COGSAccountCode = _expenseAccountCode
                },
                SalesDetails = new SalesDetails
                {
                    UnitPrice = 1020.5555m,
                    AccountCode = _revenueAccountCode,
                    TaxType = "OUTPUT2"
                },

                Name = "Full Tracked Item",
                IsTrackedAsInventory = true,
                InventoryAssetAccountCode = _inventoryAccountCode,
                IsSold = true,
                IsPurchased = true
            });

            _createdItem = item;
        }

        private void Given_a_direct_cost_account()
        {
            var expenseAccount = Api.Accounts.Where("Type == \"DIRECTCOSTS\"").Find().FirstOrDefault();

            if (expenseAccount == null)
            {
                expenseAccount = Api.Accounts.Create(new Account
                {
                    Code = Random.GetRandomString(10),
                    Type = AccountType.DirectCosts,
                    Description = "Direct costs account",
                    Name = "Direct costs account"
                });
            }

            _expenseAccountCode = expenseAccount.Code;

        }

        private void Given_a_revenue_account()
        {
            var revenueAccount = Api.Accounts.Where("Type == \"REVENUE\"").Find().FirstOrDefault();

            if (revenueAccount == null)
            {
                revenueAccount = Api.Accounts.Create(new Account
                {
                    Code = Random.GetRandomString(10),
                    Type = AccountType.Revenue,
                    Description = "Revenue account",
                    Name = "Revenue account"
                });
            }

            _revenueAccountCode = revenueAccount.Code;

        }


        private void Given_an_inventory_account()
        {
            var inventoryAccount = Api.Accounts.Where("Type == \"INVENTORY\"").Find().FirstOrDefault();

            if (inventoryAccount == null)
            {
                inventoryAccount = Api.Accounts.Create(new Account
                {
                    Code = Random.GetRandomString(10),
                    Type = AccountType.Inventory,
                    Description = "The account to hold all the things",
                    Name = "My inventory account"
                });
            }

            _inventoryAccountCode = inventoryAccount.Code;
        }
    }

    
}
