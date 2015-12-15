using System.Collections.Generic;
using Xero.Api.Core.Endpoints;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Setup;
using Organisation = Xero.Api.Core.Model.Organisation;

namespace Xero.Api.Core
{
    public interface IXeroCoreApi
    {
        AccountsEndpoint Accounts { get; }
        AllocationsEndpoint Allocations { get; }
        AttachmentsEndpoint Attachments { get; }
        BankTransactionsEndpoint BankTransactions { get; }
        BankTransfersEndpoint BankTransfers { get; }
        BrandingThemesEndpoint BrandingThemes { get; }
        ContactsEndpoint Contacts { get; }
        ContactGroupsEndpoint ContactGroups { get; }
        CreditNotesEndpoint CreditNotes { get; }
        CurrenciesEndpoint Currencies { get; set; }
        EmployeesEndpoint Employees { get; }
        ExpenseClaimsEndpoint ExpenseClaims { get; }
        FilesEndpoint Files { get; }
        FoldersEndpoint Folders { get; }
        InboxEndpoint Inbox { get; }
        InvoicesEndpoint Invoices { get; }
        ItemsEndpoint Items { get; }
        IJournalsEndpoint Journals { get; }
        LinkedTransactionsEndpoint LinkedTransactions { get; }
        ManualJournalsEndpoint ManualJournals { get; }
        OverpaymentsEndpoint Overpayments { get; }
        PaymentsEndpoint Payments { get; }
        PdfEndpoint PdfFiles { get; }
        PrepaymentsEndpoint Prepayments { get; }
        PurchaseOrdersEndpoint PurchaseOrders { get; }
        ReceiptsEndpoint Receipts { get; }
        RepeatingInvoicesEndpoint RepeatingInvoices { get; }
        ReportsEndpoint Reports { get; }
        SetupEndpoint Setup { get; }
        TaxRatesEndpoint TaxRates { get; }
        TrackingCategoriesEndpoint TrackingCategories { get; }
        UsersEndpoint Users { get; }
        Organisation Organisation { get; }
        string BaseUri { get; }
        string UserAgent { get; set; }
        IEnumerable<Invoice> Create(IEnumerable<Invoice> items);
        IEnumerable<Contact> Create(IEnumerable<Contact> items);
        IEnumerable<Account> Create(IEnumerable<Account> items);
        IEnumerable<Employee> Create(IEnumerable<Employee> items);
        IEnumerable<ExpenseClaim> Create(IEnumerable<ExpenseClaim> items);
        IEnumerable<Receipt> Create(IEnumerable<Receipt> items);
        IEnumerable<CreditNote> Create(IEnumerable<CreditNote> items);
        IEnumerable<Item> Create(IEnumerable<Item> items);
        IEnumerable<ManualJournal> Create(IEnumerable<ManualJournal> items);
        IEnumerable<Payment> Create(IEnumerable<Payment> items);
        IEnumerable<TaxRate> Create(IEnumerable<TaxRate> items);
        IEnumerable<BankTransaction> Create(IEnumerable<BankTransaction> items);
        IEnumerable<BankTransfer> Create(IEnumerable<BankTransfer> items);
        Invoice Create(Invoice item);
        Contact Create(Contact item);
        Account Create(Account item);
        Employee Create(Employee item);
        ExpenseClaim Create(ExpenseClaim item);
        Receipt Create(Receipt item);
        CreditNote Create(CreditNote item);
        Item Create(Item item);
        ManualJournal Create(ManualJournal item);
        Payment Create(Payment item);
        TaxRate Create(TaxRate item);
        BankTransaction Create(BankTransaction item);
        BankTransfer Create(BankTransfer item);
        ImportSummary Create(Setup item);
        Invoice Update(Invoice item);
        Contact Update(Contact item);
        ContactGroup Update(ContactGroup item);
        Employee Update(Employee item);
        ExpenseClaim Update(ExpenseClaim item);
        Receipt Update(Receipt item);
        CreditNote Update(CreditNote item);
        Item Update(Item item);
        ManualJournal Update(ManualJournal item);
        BankTransaction Update(BankTransaction item);
        BankTransfer Update(BankTransfer item);
        TaxRate Update(TaxRate item);
        ImportSummary Update(Setup item);
        TrackingCategory Update(TrackingCategory item);
    }
}