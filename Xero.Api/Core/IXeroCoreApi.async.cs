using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Setup;
using Organisation = Xero.Api.Core.Model.Organisation;

namespace Xero.Api.Core
{
    partial interface IXeroCoreApi
    {
        Task<Organisation> GetOrganisationAsync(CancellationToken cancellation = default(CancellationToken));

        //Accounts
        Task<IList<Account>> CreateAsync(IList<Account> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<Account>> UpdateAsync(IList<Account> items, CancellationToken cancellation = default(CancellationToken));
        Task<Account> CreateAsync(Account item, CancellationToken cancellation = default(CancellationToken));
        Task<Account> UpdateAsync(Account item, CancellationToken cancellation = default(CancellationToken));

        //BankTransactions
        Task<IList<BankTransaction>> CreateAsync(IList<BankTransaction> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<BankTransaction>> UpdateAsync(IList<BankTransaction> items, CancellationToken cancellation = default(CancellationToken));
        Task<BankTransaction> CreateAsync(BankTransaction item, CancellationToken cancellation = default(CancellationToken));
        Task<BankTransaction> UpdateAsync(BankTransaction item, CancellationToken cancellation = default(CancellationToken));

        //BankTransfers
        Task<IList<BankTransfer>> CreateAsync(IList<BankTransfer> items, CancellationToken cancellation = default(CancellationToken));
        Task<BankTransfer> CreateAsync(BankTransfer item, CancellationToken cancellation = default(CancellationToken));

        //Contacts
        Task<IList<Contact>> CreateAsync(IList<Contact> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<Contact>> UpdateAsync(IList<Contact> items, CancellationToken cancellation = default(CancellationToken));
        Task<Contact> CreateAsync(Contact item, CancellationToken cancellation = default(CancellationToken));
        Task<Contact> UpdateAsync(Contact item, CancellationToken cancellation = default(CancellationToken));

        //ContactGroups
        Task<IList<ContactGroup>> CreateAsync(IList<ContactGroup> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<ContactGroup>> UpdateAsync(IList<ContactGroup> items, CancellationToken cancellation = default(CancellationToken));
        Task<ContactGroup> CreateAsync(ContactGroup item, CancellationToken cancellation = default(CancellationToken));
        Task<ContactGroup> UpdateAsync(ContactGroup item, CancellationToken cancellation = default(CancellationToken));

        //CreditNotes
        Task<IList<CreditNote>> CreateAsync(IList<CreditNote> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<CreditNote>> UpdateAsync(IList<CreditNote> items, CancellationToken cancellation = default(CancellationToken));
        Task<CreditNote> CreateAsync(CreditNote item, CancellationToken cancellation = default(CancellationToken));
        Task<CreditNote> UpdateAsync(CreditNote item, CancellationToken cancellation = default(CancellationToken));

        //Employees
        Task<IList<Employee>> CreateAsync(IList<Employee> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<Employee>> UpdateAsync(IList<Employee> items, CancellationToken cancellation = default(CancellationToken));
        Task<Employee> CreateAsync(Employee item, CancellationToken cancellation = default(CancellationToken));
        Task<Employee> UpdateAsync(Employee item, CancellationToken cancellation = default(CancellationToken));

        //ExpenseClaims
        Task<IList<ExpenseClaim>> CreateAsync(IList<ExpenseClaim> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<ExpenseClaim>> UpdateAsync(IList<ExpenseClaim> items, CancellationToken cancellation = default(CancellationToken));
        Task<ExpenseClaim> CreateAsync(ExpenseClaim item, CancellationToken cancellation = default(CancellationToken));
        Task<ExpenseClaim> UpdateAsync(ExpenseClaim item, CancellationToken cancellation = default(CancellationToken));

        //Invoices
        Task<IList<Invoice>> CreateAsync(IList<Invoice> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<Invoice>> UpdateAsync(IList<Invoice> items, CancellationToken cancellation = default(CancellationToken));
        Task<Invoice> CreateAsync(Invoice item, CancellationToken cancellation = default(CancellationToken));
        Task<Invoice> UpdateAsync(Invoice item, CancellationToken cancellation = default(CancellationToken));

        //Items
        Task<IList<Item>> CreateAsync(IList<Item> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<Item>> UpdateAsync(IList<Item> items, CancellationToken cancellation = default(CancellationToken));
        Task<Item> CreateAsync(Item item, CancellationToken cancellation = default(CancellationToken));
        Task<Item> UpdateAsync(Item item, CancellationToken cancellation = default(CancellationToken));

        //LinkedTransactions
        Task<IList<LinkedTransaction>> CreateAsync(IList<LinkedTransaction> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<LinkedTransaction>> UpdateAsync(IList<LinkedTransaction> items, CancellationToken cancellation = default(CancellationToken));
        Task<LinkedTransaction> CreateAsync(LinkedTransaction item, CancellationToken cancellation = default(CancellationToken));
        Task<LinkedTransaction> UpdateAsync(LinkedTransaction item, CancellationToken cancellation = default(CancellationToken));

        //ManualJournals
        Task<IList<ManualJournal>> CreateAsync(IList<ManualJournal> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<ManualJournal>> UpdateAsync(IList<ManualJournal> items, CancellationToken cancellation = default(CancellationToken));
        Task<ManualJournal> CreateAsync(ManualJournal item, CancellationToken cancellation = default(CancellationToken));
        Task<ManualJournal> UpdateAsync(ManualJournal item, CancellationToken cancellation = default(CancellationToken));


        //Payments
        Task<IList<Payment>> CreateAsync(IList<Payment> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<Payment>> UpdateAsync(IList<Payment> items, CancellationToken cancellation = default(CancellationToken));
        Task<Payment> CreateAsync(Payment item, CancellationToken cancellation = default(CancellationToken));
        Task<Payment> UpdateAsync(Payment item, CancellationToken cancellation = default(CancellationToken));

        //PurchaseOrders
        Task<IList<PurchaseOrder>> CreateAsync(IList<PurchaseOrder> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<PurchaseOrder>> UpdateAsync(IList<PurchaseOrder> items, CancellationToken cancellation = default(CancellationToken));
        Task<PurchaseOrder> CreateAsync(PurchaseOrder item, CancellationToken cancellation = default(CancellationToken));
        Task<PurchaseOrder> UpdateAsync(PurchaseOrder item, CancellationToken cancellation = default(CancellationToken));

        //Receipts
        Task<IList<Receipt>> CreateAsync(IList<Receipt> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<Receipt>> UpdateAsync(IList<Receipt> items, CancellationToken cancellation = default(CancellationToken));
        Task<Receipt> CreateAsync(Receipt item, CancellationToken cancellation = default(CancellationToken));
        Task<Receipt> UpdateAsync(Receipt item, CancellationToken cancellation = default(CancellationToken));

        //Setups
        Task<ImportSummary> CreateAsync(Setup item, CancellationToken cancellation = default(CancellationToken));
        Task<ImportSummary> UpdateAsync(Setup item, CancellationToken cancellation = default(CancellationToken));

        //TaxRates
        Task<IList<TaxRate>> CreateAsync(IList<TaxRate> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<TaxRate>> UpdateAsync(IList<TaxRate> items, CancellationToken cancellation = default(CancellationToken));
        Task<TaxRate> CreateAsync(TaxRate item, CancellationToken cancellation = default(CancellationToken));
        Task<TaxRate> UpdateAsync(TaxRate item, CancellationToken cancellation = default(CancellationToken));

        //TrackingCategories
        Task<IList<TrackingCategory>> CreateAsync(IList<TrackingCategory> items, CancellationToken cancellation = default(CancellationToken));
        Task<IList<TrackingCategory>> UpdateAsync(IList<TrackingCategory> items, CancellationToken cancellation = default(CancellationToken));
        Task<TrackingCategory> CreateAsync(TrackingCategory item, CancellationToken cancellation = default(CancellationToken));
        Task<TrackingCategory> UpdateAsync(TrackingCategory item, CancellationToken cancellation = default(CancellationToken));
    }
}
