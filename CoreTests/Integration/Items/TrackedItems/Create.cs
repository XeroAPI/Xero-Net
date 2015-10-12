using System;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Items.TrackedItems
{
    public class Create : ApiWrapperTest
    {
        private string _inventoryAccountCode;
        private string _expenseAccountCode;
        private string _revenueAccountCode;

        [Test]
        public void Can_create_an_item_with_minimal_properties()
        {
            var org = Api.Users.Find();

            Given_an_inventory_account();
            Given_an_expense_account();

            var item = Api.Items.Create(new Item
            {
                Code = "Tracked Item " + Random.GetRandomString(10),
                InventoryAssetAccountCode = _inventoryAccountCode,
                PurchaseDetails = new PurchaseDetails
                {
                    COGSAccountCode = _expenseAccountCode
                }

            });

            Assert.True(item.IsTrackedAsInventory, "Expected the item to be tracked as inventory, but IsTrackedAsInventory is false");
        }

        [Test]
        public void Can_create_an_item_with_full_details()
        {
            Given_an_inventory_account();
            Given_an_expense_account();
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

            Assert.True(item.Id != Guid.Empty);
            Assert.True(item.IsTrackedAsInventory = true);
            Assert.AreEqual(item.Code, code, string.Format("Expected the create item's code '{0}' to equal '{1}', but were not equal", item.Code, code));
        }

        private void Given_an_expense_account()
        {
            var expenseAccount = Api.Accounts.Where("Type == \"EXPENSE\"").Find().FirstOrDefault();

            if (expenseAccount == null)
            {
                expenseAccount = Api.Accounts.Create(new Account
                {
                    Code = Random.GetRandomString(10),
                    Type = AccountType.Expense,
                    Description = "Cost of goods sold account",
                    Name = "COGS"
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
