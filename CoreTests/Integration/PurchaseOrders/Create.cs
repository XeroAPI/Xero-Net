using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.PurchaseOrders
{
    public class Create : ApiWrapperTest
    {
        [Test]
        public void Create_minimal_draft_purchase_order()
        {

            var purchaseOrder = Api.PurchaseOrders.Create(
                new PurchaseOrder
                {
                    Date = DateTime.Today,
                    Contact = new Contact { Id = ContactId }
                }
            );

            Assert.True(purchaseOrder.Id != Guid.Empty);
            Assert.True(purchaseOrder.Status == PurchaseOrderStatus.Draft);
        }

        [Test]
        public void Create_authorised_purchase_order()
        {
            var purchaseOrder = Api.PurchaseOrders.Create(
                new PurchaseOrder
                {
                    Status = PurchaseOrderStatus.Authorised,
                    Date = DateTime.Today,
                    Contact = new Contact{Id = ContactId},
                    LineItems = new List<LineItem>()
                    {
                        new LineItem
                        {
                            Description = "An item I want to purchase",
                            UnitAmount = 1,
                            Quantity = 1,

                        }
                    }
                }
            );

            Assert.True(purchaseOrder.Id != Guid.Empty);
            Assert.True(purchaseOrder.Status == PurchaseOrderStatus.Authorised);
        }

        private Guid ContactId
        {
            get
            {
                return Api.Contacts.Find().First().Id;
            }
        }
    }
}
