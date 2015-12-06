using System;
using NUnit.Framework;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.PurchaseOrders
{
    public class Find : ApiWrapperTest
    {

        [Test]
        public void Find_a_purchase_order_by_Id()
        {
            Api.PurchaseOrders.Find(Guid.NewGuid());
        }

        [Test]
        public void Find_purchase_orders()
        {
            Api.PurchaseOrders.Find();
        }

        [Test]
        public void Find_page_X_of_purchase_orders()
        {
            Api.PurchaseOrders.Page(1).Find();
        }

        [Test]
        public void Filter_purchase_orders_by_status()
        {
            Api.PurchaseOrders.Status(PurchaseOrderStatus.Authorised).Find();
        }

        [Test]
        public void Filter_purchase_orders_by_ModifiedSince()
        {
            Api.PurchaseOrders.ModifiedSince(DateTime.Today.AddDays(-1)).Find();
        }

        [Test]
        public void Filter_purchase_orders_by_DateFrom()
        {
            Api.PurchaseOrders.DateFrom(DateTime.Today.AddDays(-7)).Find();
        }

        [Test]
        public void Filter_purchase_orders_by_DateTo()
        {
            Api.PurchaseOrders.DateTo(DateTime.Today.AddDays(-1)).Find();
        }

        [Test]
        public void Filter_purchase_orders_by_a_DateFrom_DateTo_date_range()
        {
            Api.PurchaseOrders
                .DateFrom(DateTime.Today.AddDays(-7))
                .DateTo(DateTime.Today.AddDays(-1))
                .Find();
        }

        [Test]
        public void Use_multiple_filters_to_find_Purchase_orders()
        {
            Api.PurchaseOrders
                .DateFrom(DateTime.Today.AddDays(-7))
                .DateTo(DateTime.Today.AddDays(-1))
                .Status(PurchaseOrderStatus.Authorised)
                .Page(1)
                .Find();
        }

    }
}
