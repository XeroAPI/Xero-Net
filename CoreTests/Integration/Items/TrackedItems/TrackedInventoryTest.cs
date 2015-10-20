using System;
using System.Collections.Generic;
using System.Linq;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Items.TrackedItems
{
    public class TrackedInventoryTest : ApiWrapperTest
    {
        protected Item CreatedItem;
        protected Invoice CreatedAccpayInvoice { get; set; }
        protected Invoice CreatedAccrecInvoice { get; set; }
        protected string InventoryAccountCode;
        protected string DirectCostsAccountCode;
        protected string RevenueAccountCode;

        public void Given_a_tracked_item()
        {
            if (string.IsNullOrEmpty(InventoryAccountCode))
            {
                Given_an_inventory_account();
            }

            if (string.IsNullOrEmpty(DirectCostsAccountCode))
            {
                Given_a_direct_cost_account();
            }

            if (string.IsNullOrEmpty(RevenueAccountCode))
            {
                Given_a_revenue_account();
            }

            var code = "Tracked Item" + Random.GetRandomString(10);

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

        protected void Given_an_ACCPAY_invoice_using_the_item_with_code(string code)
        {
            var invoice = new Invoice
            {
                Contact = new Contact { Name = "ABC Bank" },
                Type = InvoiceType.AccountsPayable,
                Date = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(90),
                LineAmountTypes = LineAmountType.Inclusive,
                Status = InvoiceStatus.Authorised,
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        ItemCode = code,
                        AccountCode = InventoryAccountCode,
                        Quantity = 2
                    }
                }

            };

            CreatedAccpayInvoice = Api.Invoices.Create(invoice);
        }


        protected void Given_a_zero_total_ACCPAY_invoice_using_the_item_with_code(string code)
        {
            var invoice = new Invoice
            {
                Contact = new Contact { Name = "ABC Bank" },
                Type = InvoiceType.AccountsPayable,
                Date = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(90),
                LineAmountTypes = LineAmountType.Inclusive,
                Status = InvoiceStatus.Authorised,
				LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        ItemCode = code,
                        AccountCode = InventoryAccountCode,
                        Quantity = 2
                    },
                    new LineItem
                    {
                        Description = "Inventory Adjustment",
                        AccountCode = DirectCostsAccountCode, //Using this account for the example. You would probably have your own inventory adjustments account
                        Quantity = 2,
                        UnitAmount = CreatedItem.PurchaseDetails.UnitPrice * -1
                    }
                }
                
            };

            CreatedAccpayInvoice = Api.Invoices.Create(invoice);
        }

        protected void Given_an_ACCREC_invoice_using_the_item_with_code(string code)
        {
            var invoice = new Invoice
            {
                Contact = new Contact { Name = "ABC Bank" },
                Type = InvoiceType.AccountsReceivable,
                Date = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(90),
                LineAmountTypes = LineAmountType.Inclusive,
                Status = InvoiceStatus.Authorised,
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        ItemCode = code,
                        AccountCode = RevenueAccountCode,
                        Quantity = 2
                    }
                }
            };

            CreatedAccrecInvoice = Api.Invoices.Create(invoice);
        }

        protected void Given_a_zero_total_ACCREC_invoice_using_the_item_with_code(string code)
        {
            var invoice = new Invoice
            {
                Contact = new Contact { Name = "ABC Bank" },
                Type = InvoiceType.AccountsReceivable,
                Date = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(90),
                LineAmountTypes = LineAmountType.Inclusive,
                Status = InvoiceStatus.Authorised,
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        ItemCode = code,
                        AccountCode = RevenueAccountCode,
                        Quantity = 2
                    },
                    new LineItem
                    {
                        Description = "Inventory Adjustment",
                        AccountCode = DirectCostsAccountCode, //Using this account for the example. You would probably want to have your own inventory adjustments account
                        Quantity = 2,
                        UnitAmount = CreatedItem.PurchaseDetails.UnitPrice * -1
                    }
                }

            };

            CreatedAccrecInvoice = Api.Invoices.Create(invoice);
        }
    }
}