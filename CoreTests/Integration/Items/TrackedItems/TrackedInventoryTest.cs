using System.Linq;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Items.TrackedItems
{
    public class TrackedInventoryTest : ApiWrapperTest
    {
        protected Item CreatedItem;
        protected string InventoryAccountCode;
        protected string DirectCostsAccountCode;
        protected string RevenueAccountCode;

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
                    COGSAccountCode = DirectCostsAccountCode
                },
                SalesDetails = new SalesDetails
                {
                    UnitPrice = 1020.5555m,
                    AccountCode = RevenueAccountCode,
                    TaxType = "OUTPUT2"
                },

                Name = "Full Tracked Item",
                IsTrackedAsInventory = true,
                InventoryAssetAccountCode = InventoryAccountCode,
                IsSold = true,
                IsPurchased = true
            });

            CreatedItem = item;
        }

        protected void Given_a_direct_cost_account()
        {
            var directCostsAccount = Api.Accounts.Where("Type == \"DIRECTCOSTS\"").Find().FirstOrDefault();

            if (directCostsAccount == null)
            {
                directCostsAccount = Api.Accounts.Create(new Account
                {
                    Code = Random.GetRandomString(10),
                    Type = AccountType.DirectCosts,
                    Description = "Direct costs account",
                    Name = "Direct costs account"
                });
            }

            DirectCostsAccountCode = directCostsAccount.Code;

        }

        protected void Given_a_revenue_account()
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

            RevenueAccountCode = revenueAccount.Code;

        }


        protected void Given_an_inventory_account()
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

            InventoryAccountCode = inventoryAccount.Code;
        }
    }
}