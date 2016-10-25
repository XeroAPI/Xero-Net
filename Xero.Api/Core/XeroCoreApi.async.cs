using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Setup;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.RateLimiter;
using Xero.Api.Serialization;

using Organisation = Xero.Api.Core.Model.Organisation;

namespace Xero.Api.Core
{
    public partial class XeroCoreApi : IXeroCoreApi
    {
        public XeroCoreApi(string baseUri, IAsyncAuthenticator auth, IConsumer consumer, IUser user,
            IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper)
            : this(baseUri, auth, consumer, user, readMapper, writeMapper, null)
        {
        }

        public XeroCoreApi(string baseUri, IAsyncAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper, IAsyncRateLimiter rateLimiter)
            : base(baseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter)
        {
            Connect();
        }

        public XeroCoreApi(string baseUri, IAsyncCertificateAuthenticator auth, IConsumer consumer, IUser user,
            IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper)
            : this(baseUri, auth, consumer, user, readMapper, writeMapper, null)
        {
        }

        public XeroCoreApi(string baseUri, IAsyncCertificateAuthenticator auth, IConsumer consumer, IUser user, IJsonObjectMapper readMapper, IXmlObjectMapper writeMapper, IAsyncRateLimiter rateLimiter)
            : base(baseUri, auth, consumer, user, readMapper, writeMapper, rateLimiter)
        {
            Connect();
        }

        public XeroCoreApi(string baseUri, IAsyncAuthenticator auth, IConsumer consumer, IUser user)
            : this(baseUri, auth, consumer, user, null)
        {
        }

        public XeroCoreApi(string baseUri, IAsyncAuthenticator auth, IConsumer consumer, IUser user, IAsyncRateLimiter rateLimiter)
            : this(baseUri, auth, consumer, user, new DefaultMapper(), new DefaultMapper())
        {
        }

        public XeroCoreApi(string baseUri, IAsyncCertificateAuthenticator auth, IConsumer consumer, IUser user)
            : this(baseUri, auth, consumer, user, null)
        {
        }

        public XeroCoreApi(string baseUri, IAsyncCertificateAuthenticator auth, IConsumer consumer, IUser user, IAsyncRateLimiter rateLimiter)
            : this(baseUri, auth, consumer, user, new DefaultMapper(), new DefaultMapper(), rateLimiter)
        {
        }

        public async Task<Organisation> GetOrganisationAsync()
        {
            return (await OrganisationEndpoint.FindAsync()).FirstOrDefault();
        }

        #region Accounts

        public Task<IList<Account>> CreateAsync(IList<Account> items)
        {
            return Accounts.CreateAsync(items);
        }

        public Task<IList<Account>> UpdateAsync(IList<Account> items)
        {
            return Accounts.UpdateAsync(items);
        }

        public Task<Account> CreateAsync(Account item)
        {
            return Accounts.CreateAsync(item);
        }

        public Task<Account> UpdateAsync(Account item)
        {
            return Accounts.UpdateAsync(item);
        }

        #endregion

        #region BankTransactions

        public Task<IList<BankTransaction>> CreateAsync(IList<BankTransaction> items)
        {
            return BankTransactions.CreateAsync(items);
        }

        public Task<IList<BankTransaction>> UpdateAsync(IList<BankTransaction> items)
        {
            return BankTransactions.UpdateAsync(items);
        }

        public Task<BankTransaction> CreateAsync(BankTransaction item)
        {
            return BankTransactions.CreateAsync(item);
        }

        public Task<BankTransaction> UpdateAsync(BankTransaction item)
        {
            return BankTransactions.UpdateAsync(item);
        }

        #endregion

        #region BankTransfers

        public Task<IList<BankTransfer>> CreateAsync(IList<BankTransfer> items)
        {
            return BankTransfers.CreateAsync(items);
        }

        public Task<BankTransfer> CreateAsync(BankTransfer item)
        {
            return BankTransfers.CreateAsync(item);
        }

        #endregion

        #region Contacts

        public Task<IList<Contact>> CreateAsync(IList<Contact> items)
        {
            return Contacts.CreateAsync(items);
        }

        public Task<IList<Contact>> UpdateAsync(IList<Contact> items)
        {
            return Contacts.UpdateAsync(items);
        }

        public Task<Contact> CreateAsync(Contact item)
        {
            return Contacts.CreateAsync(item);
        }

        public Task<Contact> UpdateAsync(Contact item)
        {
            return Contacts.UpdateAsync(item);
        }

        #endregion

        #region ContactGroups

        public Task<IList<ContactGroup>> CreateAsync(IList<ContactGroup> items)
        {
            return ContactGroups.CreateAsync(items);
        }

        public Task<IList<ContactGroup>> UpdateAsync(IList<ContactGroup> items)
        {
            return ContactGroups.UpdateAsync(items);
        }

        public Task<ContactGroup> CreateAsync(ContactGroup item)
        {
            return ContactGroups.CreateAsync(item);
        }

        public Task<ContactGroup> UpdateAsync(ContactGroup item)
        {
            return ContactGroups.UpdateAsync(item);
        }

        #endregion

        #region CreditNotes

        public Task<IList<CreditNote>> CreateAsync(IList<CreditNote> items)
        {
            return CreditNotes.CreateAsync(items);
        }

        public Task<IList<CreditNote>> UpdateAsync(IList<CreditNote> items)
        {
            return CreditNotes.UpdateAsync(items);
        }

        public Task<CreditNote> CreateAsync(CreditNote item)
        {
            return CreditNotes.CreateAsync(item);
        }

        public Task<CreditNote> UpdateAsync(CreditNote item)
        {
            return CreditNotes.UpdateAsync(item);
        }

        #endregion

        #region Employees

        public Task<IList<Employee>> CreateAsync(IList<Employee> items)
        {
            return Employees.CreateAsync(items);
        }

        public Task<IList<Employee>> UpdateAsync(IList<Employee> items)
        {
            return Employees.UpdateAsync(items);
        }

        public Task<Employee> CreateAsync(Employee item)
        {
            return Employees.CreateAsync(item);
        }

        public Task<Employee> UpdateAsync(Employee item)
        {
            return Employees.UpdateAsync(item);
        }

        #endregion

        #region ExpenseClaims

        public Task<IList<ExpenseClaim>> CreateAsync(IList<ExpenseClaim> items)
        {
            return ExpenseClaims.CreateAsync(items);
        }

        public Task<IList<ExpenseClaim>> UpdateAsync(IList<ExpenseClaim> items)
        {
            return ExpenseClaims.UpdateAsync(items);
        }

        public Task<ExpenseClaim> CreateAsync(ExpenseClaim item)
        {
            return ExpenseClaims.CreateAsync(item);
        }

        public Task<ExpenseClaim> UpdateAsync(ExpenseClaim item)
        {
            return ExpenseClaims.UpdateAsync(item);
        }

        #endregion

        #region Invoices

        public Task<IList<Invoice>> CreateAsync(IList<Invoice> items)
        {
            return Invoices.CreateAsync(items);
        }

        public Task<IList<Invoice>> UpdateAsync(IList<Invoice> items)
        {
            return Invoices.UpdateAsync(items);
        }

        public Task<Invoice> CreateAsync(Invoice item)
        {
            return Invoices.CreateAsync(item);
        }

        public Task<Invoice> UpdateAsync(Invoice item)
        {
            return Invoices.UpdateAsync(item);
        }

        #endregion

        #region Items

        public Task<IList<Item>> CreateAsync(IList<Item> items)
        {
            return Items.CreateAsync(items);
        }

        public Task<IList<Item>> UpdateAsync(IList<Item> items)
        {
            return Items.UpdateAsync(items);
        }

        public Task<Item> CreateAsync(Item item)
        {
            return Items.CreateAsync(item);
        }

        public Task<Item> UpdateAsync(Item item)
        {
            return Items.UpdateAsync(item);
        }

        #endregion

        #region LinkedTransactions

        public Task<IList<LinkedTransaction>> CreateAsync(IList<LinkedTransaction> items)
        {
            return LinkedTransactions.CreateAsync(items);
        }

        public Task<IList<LinkedTransaction>> UpdateAsync(IList<LinkedTransaction> items)
        {
            return LinkedTransactions.UpdateAsync(items);
        }

        public Task<LinkedTransaction> CreateAsync(LinkedTransaction item)
        {
            return LinkedTransactions.CreateAsync(item);
        }

        public Task<LinkedTransaction> UpdateAsync(LinkedTransaction item)
        {
            return LinkedTransactions.UpdateAsync(item);
        }

        #endregion

        #region ManualJournals

        public Task<IList<ManualJournal>> CreateAsync(IList<ManualJournal> items)
        {
            return ManualJournals.CreateAsync(items);
        }

        public Task<IList<ManualJournal>> UpdateAsync(IList<ManualJournal> items)
        {
            return ManualJournals.UpdateAsync(items);
        }

        public Task<ManualJournal> CreateAsync(ManualJournal item)
        {
            return ManualJournals.CreateAsync(item);
        }

        public Task<ManualJournal> UpdateAsync(ManualJournal item)
        {
            return ManualJournals.UpdateAsync(item);
        }

        #endregion

        #region Payments

        public Task<IList<Payment>> CreateAsync(IList<Payment> items)
        {
            return Payments.CreateAsync(items);
        }

        public Task<IList<Payment>> UpdateAsync(IList<Payment> items)
        {
            return Payments.UpdateAsync(items);
        }

        public Task<Payment> CreateAsync(Payment item)
        {
            return Payments.CreateAsync(item);
        }

        public Task<Payment> UpdateAsync(Payment item)
        {
            return Payments.UpdateAsync(item);
        }

        #endregion

        #region PurchaseOrders

        public Task<IList<PurchaseOrder>> CreateAsync(IList<PurchaseOrder> items)
        {
            return PurchaseOrders.CreateAsync(items);
        }

        public Task<IList<PurchaseOrder>> UpdateAsync(IList<PurchaseOrder> items)
        {
            return PurchaseOrders.UpdateAsync(items);
        }

        public Task<PurchaseOrder> CreateAsync(PurchaseOrder item)
        {
            return PurchaseOrders.CreateAsync(item);
        }

        public Task<PurchaseOrder> UpdateAsync(PurchaseOrder item)
        {
            return PurchaseOrders.UpdateAsync(item);
        }

        #endregion

        #region Receipts

        public Task<IList<Receipt>> CreateAsync(IList<Receipt> items)
        {
            return Receipts.CreateAsync(items);
        }

        public Task<IList<Receipt>> UpdateAsync(IList<Receipt> items)
        {
            return Receipts.UpdateAsync(items);
        }

        public Task<Receipt> CreateAsync(Receipt item)
        {
            return Receipts.CreateAsync(item);
        }

        public Task<Receipt> UpdateAsync(Receipt item)
        {
            return Receipts.UpdateAsync(item);
        }

        #endregion

        #region Setups

        public Task<ImportSummary> CreateAsync(Setup item)
        {
            return Setup.CreateAsync(item);
        }

        public Task<ImportSummary> UpdateAsync(Setup item)
        {
            return Setup.UpdateAsync(item);
        }

        #endregion

        #region TaxRates

        public Task<IList<TaxRate>> CreateAsync(IList<TaxRate> items)
        {
            return TaxRates.CreateAsync(items);
        }

        public Task<IList<TaxRate>> UpdateAsync(IList<TaxRate> items)
        {
            return TaxRates.UpdateAsync(items);
        }

        public Task<TaxRate> CreateAsync(TaxRate item)
        {
            return TaxRates.CreateAsync(item);
        }

        public Task<TaxRate> UpdateAsync(TaxRate item)
        {
            return TaxRates.UpdateAsync(item);
        }

        #endregion

        #region TrackingCategories

        public Task<IList<TrackingCategory>> CreateAsync(IList<TrackingCategory> items)
        {
            return TrackingCategories.CreateAsync(items);
        }

        public Task<IList<TrackingCategory>> UpdateAsync(IList<TrackingCategory> items)
        {
            return TrackingCategories.UpdateAsync(items);
        }

        public Task<TrackingCategory> CreateAsync(TrackingCategory item)
        {
            return TrackingCategories.CreateAsync(item);
        }

        public Task<TrackingCategory> UpdateAsync(TrackingCategory item)
        {
            return TrackingCategories.UpdateAsync(item);
        }

        #endregion
    }
}
