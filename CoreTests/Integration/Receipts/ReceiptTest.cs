using System;
using System.Collections.Generic;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.Receipts
{
    public abstract class ReceiptTest : ApiWrapperTest
    {
        public Receipt Given_a_receipt(Guid userId, string contactName, string description, decimal amount, string account)
        {
            return Api.Create(new Receipt
            {
                Date = DateTime.UtcNow.Date,
                Contact = new Contact { Name = contactName },
                LineAmountTypes = LineAmountType.Inclusive,
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        Description = description,
                        UnitAmount = amount,
                        AccountCode = account
                    }
                },
                Total = amount,
                User = new User
                {
                    Id = userId
                }
            });
        }
    }
}
