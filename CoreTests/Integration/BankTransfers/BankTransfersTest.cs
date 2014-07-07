using System;
using System.Collections.Generic;
using System.Linq;
using Xero.Api.Core.Model;

namespace CoreTests.Integration.BankTransfers
{
    public abstract class BankTransfersTest : ApiWrapperTest
    {

        public BankTransfer Given_a_bank_transfer(Decimal amount)
        {
            var accountIds = get_bankaccount_ids();
   
            var newBankTransfer = new BankTransfer
            {
                FromBankAccount = new Account { Id = accountIds[0] },
                ToBankAccount = new Account { Id = accountIds[1] },
                Amount = amount
            };
            
            return Api.Create(newBankTransfer);
        }


        public IList<Guid> get_bankaccount_ids()
        {
            return Api.Accounts.Where("Type == \"BANK\"")
                .Find()
                .Select(p => p.Id)
                .ToList();
        }
    }
}
