using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.PurchaseOrders
{
    public class Find : ApiWrapperTest
    {

        [Test]
        public void Find_a_purchase_order_by_Id()
        {
            var purchaseOrder = Given_a_minimum_PurchaseOrder();

            var foundPurchaseOrder = Api.PurchaseOrders.Find(purchaseOrder.Id);

            Assert.AreEqual(purchaseOrder.Id, foundPurchaseOrder.Id);
        }

        [Test]
        public void Find_purchase_orders()
        {
            Given_a_minimum_PurchaseOrder();

            var foundPurchaseOrders = Api.PurchaseOrders.Find();

            Assert.GreaterOrEqual(foundPurchaseOrders.Count(), 1);
        }

        [Test]
        public void Find_page_X_of_purchase_orders()
        {
            Given_a_minimum_PurchaseOrder();

            var foundPurchaseOrders = Api.PurchaseOrders.Page(1).Find();

            Assert.GreaterOrEqual(foundPurchaseOrders.Count(), 1);
        }

        [Test]
        public void Filter_purchase_orders_by_status()
        {
            Given_an_authorised_PurchaseOrder();

            var authorisedPurchaseOrders = Api.PurchaseOrders.Status(PurchaseOrderStatus.Authorised).Find();

            Assert.IsTrue(authorisedPurchaseOrders.All(p => p.Status == PurchaseOrderStatus.Authorised), "Expected all retrieved purchase orders to have status of Authorised");
        }

        [Test]
        public void Filter_purchase_orders_by_ModifiedSince()
        {
            var oldPurchaseOrder = Given_a_minimum_PurchaseOrder();

            Thread.Sleep(1000);

            var date = DateTime.UtcNow;

            Thread.Sleep(1000);

            var newPurchaseOrder = Given_a_minimum_PurchaseOrder();

            var retrievedPurchaseOrders = Api.PurchaseOrders.ModifiedSince(date).Find().ToList();

            Assert.True(retrievedPurchaseOrders.All(p => p.Id != oldPurchaseOrder.Id));
            Assert.True(retrievedPurchaseOrders.Any(p => p.Id == newPurchaseOrder.Id));
        }

        [Test]
        public void Filter_purchase_orders_by_DateFrom()
        {
            var oldPurchaseOrder = Given_a_minimum_PurchaseOrder(DateTime.Today.AddDays(-7));

            var newPurchaseOrder = Given_a_minimum_PurchaseOrder(DateTime.Today);

            var inbetweenDate = DateTime.Today.AddDays(-3);
            
            var retrievedPurchaseOrders = Api.PurchaseOrders.DateFrom(inbetweenDate).Find().ToList();

            Assert.True(retrievedPurchaseOrders.All(p => p.Id != oldPurchaseOrder.Id));
            Assert.True(retrievedPurchaseOrders.Any(p => p.Id == newPurchaseOrder.Id));
        }

        [Test]
        public void Filter_purchase_orders_by_DateTo()
        {
            var oldPurchaseOrder = Given_a_minimum_PurchaseOrder(DateTime.Today.AddDays(-7));

            var newPurchaseOrder = Given_a_minimum_PurchaseOrder(DateTime.Today);

            var inbetweenDate = DateTime.Today.AddDays(-3);

            var retrievedPurchaseOrders = Api.PurchaseOrders.DateTo(inbetweenDate).Find().ToList();

            Assert.True(retrievedPurchaseOrders.All(p => p.Id != newPurchaseOrder.Id));
            Assert.True(retrievedPurchaseOrders.Any(p => p.Id == oldPurchaseOrder.Id));
        }

        [Test]
        public void Filter_purchase_orders_by_a_DateFrom_DateTo_date_range()
        {
            var oldPurchaseOrder = Given_a_minimum_PurchaseOrder(DateTime.Today.AddDays(-7));

            var midPurchaseOrder = Given_a_minimum_PurchaseOrder(DateTime.Today.AddDays(-4));

            var newPurchaseOrder = Given_a_minimum_PurchaseOrder(DateTime.Today);

            var dateFrom = DateTime.Today.AddDays(-5);
            var dateTo = DateTime.Today.AddDays(-3);

            var retrievedPurchaseOrders = Api.PurchaseOrders
                .DateFrom(dateFrom)
                .DateTo(dateTo)
                .Find().ToList();

            Assert.True(retrievedPurchaseOrders.All(p => p.Id != newPurchaseOrder.Id));
            Assert.True(retrievedPurchaseOrders.All(p => p.Id != oldPurchaseOrder.Id));

            Assert.True(retrievedPurchaseOrders.Any(p => p.Id == midPurchaseOrder.Id));

        }

        [Test]
        public void Use_multiple_filters_to_find_Purchase_orders()
        {
            var purchaseOrders = Api.PurchaseOrders
                .DateFrom(DateTime.Today.AddDays(-7))
                .DateTo(DateTime.Today.AddDays(-1))
                .Status(PurchaseOrderStatus.Authorised)
                .Page(1)
                .Find();

            Assert.GreaterOrEqual(purchaseOrders.Count(), 1);
        }

        private PurchaseOrder Given_a_minimum_PurchaseOrder(DateTime? date = null)
        {
            var purchaseOrder = Api.PurchaseOrders.Create(new PurchaseOrder
            {
                Date = date ?? DateTime.Today,
                Contact = Api.Contacts.Find().First()
            });
            return purchaseOrder;
        }

        private PurchaseOrder Given_an_authorised_PurchaseOrder()
        {
            var purchaseOrder = Api.PurchaseOrders.Create(new PurchaseOrder
            {
                Status = PurchaseOrderStatus.Authorised,
                Date = DateTime.Today,
                Contact = Api.Contacts.Find().First(),
                LineItems = new List<LineItem>()
                {
                    new LineItem
                    {
                        Description = "An item I want to purchase",
                        UnitAmount = 1,
                        Quantity = 1,

                    }
                }
            });
            return purchaseOrder;
        }



    }
}
