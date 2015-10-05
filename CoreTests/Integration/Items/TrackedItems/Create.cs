using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Items.TrackedItems
{
    public class Create : ApiWrapperTest
    {
        private string _inventoryAccountCode;
        private string _normalAccountCode;

        [Test]
        public void Can_create_an_item_with_minimal_properties()
        {
            Given_an_inventory_account();
            Given_a_normal_account();

            var item = Api.Items.Create(new Item
            {
                Code = "Tracked Item " + Random.GetRandomString(10),
                InventoryAssetAccountCode = _inventoryAccountCode,
                PurchaseDetails = new PurchaseDetails
                {
                    COGSAccountCode = _normalAccountCode
                }

            });

            Assert.True(item.IsTrackedAsInventory, "Expected the item to be tracked as inventory, but IsTrackedAsInventory is false");
        }

        private void Given_a_normal_account()
        {
            var normalAccount = Api.Accounts.Where("Type == \"EXPENSE\"").Find().FirstOrDefault();

            if (normalAccount == null)
            {
                normalAccount = Api.Accounts.Create(new Account
                {
                    Code = Random.GetRandomString(10),
                    Type = AccountType.Expense,
                    Description = "Cost of goods sold account",
                    Name = "COGS"
                });
            }

            _normalAccountCode = normalAccount.Code;

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
