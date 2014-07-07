using System;
using System.Collections.Generic;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.ExpenseClaims
{
    public abstract class ExpenseClaimTest : ApiWrapperTest
    {
        public Receipt Given_a_receipt(Guid userId, string contactName, string description, decimal amount, string account)
        {
            return Api.Create(new Receipt
            {
                Date = DateTime.UtcNow.Date,
                Contact = new Contact { Name = contactName },
                LineAmountTypes = LineAmountType.Inclusive,
                Status = ReceiptStatus.Draft,
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

        public ExpenseClaim Given_an_expense_claim(Guid userId, Guid receiptId1, Guid receiptId2)
        {
            return Api.Create(new ExpenseClaim
            {
                User = new User
                {
                    Id = userId
                },
                Receipts = new List<Receipt>
                {
                    new Receipt
                    {
                        Id = receiptId1
                    },
                    new Receipt
                    {
                        Id = receiptId2
                    },
                }                
            });
        }
    }
}
