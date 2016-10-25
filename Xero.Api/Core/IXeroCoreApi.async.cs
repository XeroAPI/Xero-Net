using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Setup;
using Organisation = Xero.Api.Core.Model.Organisation;

namespace Xero.Api.Core
{
    partial interface IXeroCoreApi
    {
        Task<Organisation> GetOrganisationAsync();

        //Accounts
        Task<IList<Account>> CreateAsync(IList<Account> items);
        Task<IList<Account>> UpdateAsync(IList<Account> items);
        Task<Account> CreateAsync(Account item);
        Task<Account> UpdateAsync(Account item);

        //BankTransactions
        Task<IList<BankTransaction>> CreateAsync(IList<BankTransaction> items);
        Task<IList<BankTransaction>> UpdateAsync(IList<BankTransaction> items);
        Task<BankTransaction> CreateAsync(BankTransaction item);
        Task<BankTransaction> UpdateAsync(BankTransaction item);

        //BankTransfers
        Task<IList<BankTransfer>> CreateAsync(IList<BankTransfer> items);
        Task<BankTransfer> CreateAsync(BankTransfer item);

        //Contacts
        Task<IList<Contact>> CreateAsync(IList<Contact> items);
        Task<IList<Contact>> UpdateAsync(IList<Contact> items);
        Task<Contact> CreateAsync(Contact item);
        Task<Contact> UpdateAsync(Contact item);

        //ContactGroups
        Task<IList<ContactGroup>> CreateAsync(IList<ContactGroup> items);
        Task<IList<ContactGroup>> UpdateAsync(IList<ContactGroup> items);
        Task<ContactGroup> CreateAsync(ContactGroup item);
        Task<ContactGroup> UpdateAsync(ContactGroup item);

        //CreditNotes
        Task<IList<CreditNote>> CreateAsync(IList<CreditNote> items);
        Task<IList<CreditNote>> UpdateAsync(IList<CreditNote> items);
        Task<CreditNote> CreateAsync(CreditNote item);
        Task<CreditNote> UpdateAsync(CreditNote item);

        //Employees
        Task<IList<Employee>> CreateAsync(IList<Employee> items);
        Task<IList<Employee>> UpdateAsync(IList<Employee> items);
        Task<Employee> CreateAsync(Employee item);
        Task<Employee> UpdateAsync(Employee item);

        //ExpenseClaims
        Task<IList<ExpenseClaim>> CreateAsync(IList<ExpenseClaim> items);
        Task<IList<ExpenseClaim>> UpdateAsync(IList<ExpenseClaim> items);
        Task<ExpenseClaim> CreateAsync(ExpenseClaim item);
        Task<ExpenseClaim> UpdateAsync(ExpenseClaim item);

        //Invoices
        Task<IList<Invoice>> CreateAsync(IList<Invoice> items);
        Task<IList<Invoice>> UpdateAsync(IList<Invoice> items);
        Task<Invoice> CreateAsync(Invoice item);
        Task<Invoice> UpdateAsync(Invoice item);

        //Items
        Task<IList<Item>> CreateAsync(IList<Item> items);
        Task<IList<Item>> UpdateAsync(IList<Item> items);
        Task<Item> CreateAsync(Item item);
        Task<Item> UpdateAsync(Item item);

        //LinkedTransactions
        Task<IList<LinkedTransaction>> CreateAsync(IList<LinkedTransaction> items);
        Task<IList<LinkedTransaction>> UpdateAsync(IList<LinkedTransaction> items);
        Task<LinkedTransaction> CreateAsync(LinkedTransaction item);
        Task<LinkedTransaction> UpdateAsync(LinkedTransaction item);

        //ManualJournals
        Task<IList<ManualJournal>> CreateAsync(IList<ManualJournal> items);
        Task<IList<ManualJournal>> UpdateAsync(IList<ManualJournal> items);
        Task<ManualJournal> CreateAsync(ManualJournal item);
        Task<ManualJournal> UpdateAsync(ManualJournal item);


        //Payments
        Task<IList<Payment>> CreateAsync(IList<Payment> items);
        Task<IList<Payment>> UpdateAsync(IList<Payment> items);
        Task<Payment> CreateAsync(Payment item);
        Task<Payment> UpdateAsync(Payment item);

        //PurchaseOrders
        Task<IList<PurchaseOrder>> CreateAsync(IList<PurchaseOrder> items);
        Task<IList<PurchaseOrder>> UpdateAsync(IList<PurchaseOrder> items);
        Task<PurchaseOrder> CreateAsync(PurchaseOrder item);
        Task<PurchaseOrder> UpdateAsync(PurchaseOrder item);

        //Receipts
        Task<IList<Receipt>> CreateAsync(IList<Receipt> items);
        Task<IList<Receipt>> UpdateAsync(IList<Receipt> items);
        Task<Receipt> CreateAsync(Receipt item);
        Task<Receipt> UpdateAsync(Receipt item);

        //Setups
        Task<ImportSummary> CreateAsync(Setup item);
        Task<ImportSummary> UpdateAsync(Setup item);

        //TaxRates
        Task<IList<TaxRate>> CreateAsync(IList<TaxRate> items);
        Task<IList<TaxRate>> UpdateAsync(IList<TaxRate> items);
        Task<TaxRate> CreateAsync(TaxRate item);
        Task<TaxRate> UpdateAsync(TaxRate item);

        //TrackingCategories
        Task<IList<TrackingCategory>> CreateAsync(IList<TrackingCategory> items);
        Task<IList<TrackingCategory>> UpdateAsync(IList<TrackingCategory> items);
        Task<TrackingCategory> CreateAsync(TrackingCategory item);
        Task<TrackingCategory> UpdateAsync(TrackingCategory item);
    }
}
