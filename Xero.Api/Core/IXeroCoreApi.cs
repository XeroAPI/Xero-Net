using System.Collections.Generic;
using Xero.Api.Core.Endpoints;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Setup;
using Organisation = Xero.Api.Core.Model.Organisation;

namespace Xero.Api.Core
{
    public interface IXeroCoreApi
    {
        IAccountsEndpoint Accounts { get; }
        AllocationsEndpoint Allocations { get; }
        AttachmentsEndpoint Attachments { get; }
        IBankTransactionsEndpoint BankTransactions { get; }
        IBankTransfersEndpoint BankTransfers { get; }
        IBrandingThemesEndpoint BrandingThemes { get; }
        IContactsEndpoint Contacts { get; }
        IContactGroupsEndpoint ContactGroups { get; }
        ICreditNotesEndpoint CreditNotes { get; }
        ICurrenciesEndpoint Currencies { get; set; }
        IEmployeesEndpoint Employees { get; }
        IExpenseClaimsEndpoint ExpenseClaims { get; }
        IFilesEndpoint Files { get; }
        IFoldersEndpoint Folders { get; }
        IHistoryAndNotesEndpoint HistoryAndNotes { get; }
        IInboxEndpoint Inbox { get; }
        IAssociationsEndpoint Associations { get; }
        IInvoicesEndpoint Invoices { get; }
        IItemsEndpoint Items { get; }
        IJournalsEndpoint Journals { get; }
        ILinkedTransactionsEndpoint LinkedTransactions { get; }
        IManualJournalsEndpoint ManualJournals { get; }
        IOrganisationEndpoint Organisations { get; }
        IOverpaymentsEndpoint Overpayments { get; }
        IPaymentsEndpoint Payments { get; }
        PdfEndpoint PdfFiles { get; }
        IPrepaymentsEndpoint Prepayments { get; }
        IPurchaseOrdersEndpoint PurchaseOrders { get; }
        IReceiptsEndpoint Receipts { get; }
        IRepeatingInvoicesEndpoint RepeatingInvoices { get; }
        IReportsEndpoint Reports { get; }
        ISetupEndpoint Setup { get; }
        ITaxRatesEndpoint TaxRates { get; }
        ITrackingCategoriesEndpoint TrackingCategories { get; }
        IUsersEndpoint Users { get; }
        Organisation Organisation { get; }
        string BaseUri { get; }
        string UserAgent { get; set; }


        //Accounts
        IEnumerable<Account> Create(IEnumerable<Account> items);
        IEnumerable<Account> Update(IEnumerable<Account> items);
        Account Create(Account item);
        Account Update(Account item);

        //BankTransactions
        IEnumerable<BankTransaction> Create(IEnumerable<BankTransaction> items);
        IEnumerable<BankTransaction> Update(IEnumerable<BankTransaction> items);
        BankTransaction Create(BankTransaction item);
        BankTransaction Update(BankTransaction item);

        //BankTransfers
        IEnumerable<BankTransfer> Create(IEnumerable<BankTransfer> items);
        BankTransfer Create(BankTransfer item);

        //Contacts
        IEnumerable<Contact> Create(IEnumerable<Contact> items);
        IEnumerable<Contact> Update(IEnumerable<Contact> items);
        Contact Create(Contact item);
        Contact Update(Contact item);

        //ContactGroups
        IEnumerable<ContactGroup> Create(IEnumerable<ContactGroup> items);
        IEnumerable<ContactGroup> Update(IEnumerable<ContactGroup> items);
        ContactGroup Create(ContactGroup item);
        ContactGroup Update(ContactGroup item);

        //CreditNotes
        IEnumerable<CreditNote> Create(IEnumerable<CreditNote> items);
        IEnumerable<CreditNote> Update(IEnumerable<CreditNote> items);
        CreditNote Create(CreditNote item);
        CreditNote Update(CreditNote item);

        //Employees
        IEnumerable<Employee> Create(IEnumerable<Employee> items);
        IEnumerable<Employee> Update(IEnumerable<Employee> items);
        Employee Create(Employee item);
        Employee Update(Employee item);

        //ExpenseClaims
        IEnumerable<ExpenseClaim> Create(IEnumerable<ExpenseClaim> items);
        IEnumerable<ExpenseClaim> Update(IEnumerable<ExpenseClaim> items);
        ExpenseClaim Create(ExpenseClaim item);
        ExpenseClaim Update(ExpenseClaim item);

        //Invoices
        IEnumerable<Invoice> Create(IEnumerable<Invoice> items);
        IEnumerable<Invoice> Update(IEnumerable<Invoice> items);
        Invoice Create(Invoice item);
        Invoice Update(Invoice item);

        //Items
        IEnumerable<Item> Create(IEnumerable<Item> items);
        IEnumerable<Item> Update(IEnumerable<Item> items);
        Item Create(Item item);
        Item Update(Item item);

        //LinkedTransactions
        IEnumerable<LinkedTransaction> Create(IEnumerable<LinkedTransaction> items);
        IEnumerable<LinkedTransaction> Update(IEnumerable<LinkedTransaction> items);
        LinkedTransaction Create(LinkedTransaction item);
        LinkedTransaction Update(LinkedTransaction item);

        //ManualJournals
        IEnumerable<ManualJournal> Create(IEnumerable<ManualJournal> items);
        IEnumerable<ManualJournal> Update(IEnumerable<ManualJournal> items);
        ManualJournal Create(ManualJournal item);
        ManualJournal Update(ManualJournal item);

        
        //Payments
        IEnumerable<Payment> Create(IEnumerable<Payment> items);
        IEnumerable<Payment> Update(IEnumerable<Payment> items);
        Payment Create(Payment item);
        Payment Update(Payment item);
        
        //PurchaseOrders
        IEnumerable<PurchaseOrder> Create(IEnumerable<PurchaseOrder> items);
        IEnumerable<PurchaseOrder> Update(IEnumerable<PurchaseOrder> items);
        PurchaseOrder Create(PurchaseOrder item);
        PurchaseOrder Update(PurchaseOrder item);

        //Receipts
        IEnumerable<Receipt> Create(IEnumerable<Receipt> items);
        IEnumerable<Receipt> Update(IEnumerable<Receipt> items);
        Receipt Create(Receipt item);
        Receipt Update(Receipt item);

        //Setups
        ImportSummary Create(Setup item);
        ImportSummary Update(Setup item);

        //TaxRates
        IEnumerable<TaxRate> Create(IEnumerable<TaxRate> items);
        IEnumerable<TaxRate> Update(IEnumerable<TaxRate> items);
        TaxRate Create(TaxRate item);
        TaxRate Update(TaxRate item);

        //TrackingCategories
        IEnumerable<TrackingCategory> Create(IEnumerable<TrackingCategory> items);
        IEnumerable<TrackingCategory> Update(IEnumerable<TrackingCategory> items);
        TrackingCategory Create(TrackingCategory item);
        TrackingCategory Update(TrackingCategory item);

        void SummarizeErrors(bool summarize);
    }
}