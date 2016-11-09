using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public async Task<Organisation> GetOrganisationAsync(CancellationToken cancellation = default(CancellationToken))
        {
            return (await OrganisationEndpoint.FindAsync(cancellation)).FirstOrDefault();
        }

        #region Accounts

        public Task<IList<Account>> CreateAsync(IList<Account> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Accounts.CreateAsync(items, cancellation);
        }

        public Task<IList<Account>> UpdateAsync(IList<Account> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Accounts.UpdateAsync(items, cancellation);
        }

        public Task<Account> CreateAsync(Account item, CancellationToken cancellation = default(CancellationToken))
        {
            return Accounts.CreateAsync(item, cancellation);
        }

        public Task<Account> UpdateAsync(Account item, CancellationToken cancellation = default(CancellationToken))
        {
            return Accounts.UpdateAsync(item, cancellation);
        }

        #endregion

        #region BankTransactions

        public Task<IList<BankTransaction>> CreateAsync(IList<BankTransaction> items, CancellationToken cancellation = default(CancellationToken))
        {
            return BankTransactions.CreateAsync(items, cancellation);
        }

        public Task<IList<BankTransaction>> UpdateAsync(IList<BankTransaction> items, CancellationToken cancellation = default(CancellationToken))
        {
            return BankTransactions.UpdateAsync(items, cancellation);
        }

        public Task<BankTransaction> CreateAsync(BankTransaction item, CancellationToken cancellation = default(CancellationToken))
        {
            return BankTransactions.CreateAsync(item, cancellation);
        }

        public Task<BankTransaction> UpdateAsync(BankTransaction item, CancellationToken cancellation = default(CancellationToken))
        {
            return BankTransactions.UpdateAsync(item, cancellation);
        }

        #endregion

        #region BankTransfers

        public Task<IList<BankTransfer>> CreateAsync(IList<BankTransfer> items, CancellationToken cancellation = default(CancellationToken))
        {
            return BankTransfers.CreateAsync(items, cancellation);
        }

        public Task<BankTransfer> CreateAsync(BankTransfer item, CancellationToken cancellation = default(CancellationToken))
        {
            return BankTransfers.CreateAsync(item, cancellation);
        }

        #endregion

        #region Contacts

        public Task<IList<Contact>> CreateAsync(IList<Contact> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Contacts.CreateAsync(items, cancellation);
        }

        public Task<IList<Contact>> UpdateAsync(IList<Contact> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Contacts.UpdateAsync(items, cancellation);
        }

        public Task<Contact> CreateAsync(Contact item, CancellationToken cancellation = default(CancellationToken))
        {
            return Contacts.CreateAsync(item, cancellation);
        }

        public Task<Contact> UpdateAsync(Contact item, CancellationToken cancellation = default(CancellationToken))
        {
            return Contacts.UpdateAsync(item, cancellation);
        }

        #endregion

        #region ContactGroups

        public Task<IList<ContactGroup>> CreateAsync(IList<ContactGroup> items, CancellationToken cancellation = default(CancellationToken))
        {
            return ContactGroups.CreateAsync(items, cancellation);
        }

        public Task<IList<ContactGroup>> UpdateAsync(IList<ContactGroup> items, CancellationToken cancellation = default(CancellationToken))
        {
            return ContactGroups.UpdateAsync(items, cancellation);
        }

        public Task<ContactGroup> CreateAsync(ContactGroup item, CancellationToken cancellation = default(CancellationToken))
        {
            return ContactGroups.CreateAsync(item, cancellation);
        }

        public Task<ContactGroup> UpdateAsync(ContactGroup item, CancellationToken cancellation = default(CancellationToken))
        {
            return ContactGroups.UpdateAsync(item, cancellation);
        }

        #endregion

        #region CreditNotes

        public Task<IList<CreditNote>> CreateAsync(IList<CreditNote> items, CancellationToken cancellation = default(CancellationToken))
        {
            return CreditNotes.CreateAsync(items, cancellation);
        }

        public Task<IList<CreditNote>> UpdateAsync(IList<CreditNote> items, CancellationToken cancellation = default(CancellationToken))
        {
            return CreditNotes.UpdateAsync(items, cancellation);
        }

        public Task<CreditNote> CreateAsync(CreditNote item, CancellationToken cancellation = default(CancellationToken))
        {
            return CreditNotes.CreateAsync(item, cancellation);
        }

        public Task<CreditNote> UpdateAsync(CreditNote item, CancellationToken cancellation = default(CancellationToken))
        {
            return CreditNotes.UpdateAsync(item, cancellation);
        }

        #endregion

        #region Employees

        public Task<IList<Employee>> CreateAsync(IList<Employee> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Employees.CreateAsync(items, cancellation);
        }

        public Task<IList<Employee>> UpdateAsync(IList<Employee> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Employees.UpdateAsync(items, cancellation);
        }

        public Task<Employee> CreateAsync(Employee item, CancellationToken cancellation = default(CancellationToken))
        {
            return Employees.CreateAsync(item, cancellation);
        }

        public Task<Employee> UpdateAsync(Employee item, CancellationToken cancellation = default(CancellationToken))
        {
            return Employees.UpdateAsync(item, cancellation);
        }

        #endregion

        #region ExpenseClaims

        public Task<IList<ExpenseClaim>> CreateAsync(IList<ExpenseClaim> items, CancellationToken cancellation = default(CancellationToken))
        {
            return ExpenseClaims.CreateAsync(items, cancellation);
        }

        public Task<IList<ExpenseClaim>> UpdateAsync(IList<ExpenseClaim> items, CancellationToken cancellation = default(CancellationToken))
        {
            return ExpenseClaims.UpdateAsync(items, cancellation);
        }

        public Task<ExpenseClaim> CreateAsync(ExpenseClaim item, CancellationToken cancellation = default(CancellationToken))
        {
            return ExpenseClaims.CreateAsync(item, cancellation);
        }

        public Task<ExpenseClaim> UpdateAsync(ExpenseClaim item, CancellationToken cancellation = default(CancellationToken))
        {
            return ExpenseClaims.UpdateAsync(item, cancellation);
        }

        #endregion

        #region Invoices

        public Task<IList<Invoice>> CreateAsync(IList<Invoice> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Invoices.CreateAsync(items, cancellation);
        }

        public Task<IList<Invoice>> UpdateAsync(IList<Invoice> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Invoices.UpdateAsync(items, cancellation);
        }

        public Task<Invoice> CreateAsync(Invoice item, CancellationToken cancellation = default(CancellationToken))
        {
            return Invoices.CreateAsync(item, cancellation);
        }

        public Task<Invoice> UpdateAsync(Invoice item, CancellationToken cancellation = default(CancellationToken))
        {
            return Invoices.UpdateAsync(item, cancellation);
        }

        #endregion

        #region Items

        public Task<IList<Item>> CreateAsync(IList<Item> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Items.CreateAsync(items, cancellation);
        }

        public Task<IList<Item>> UpdateAsync(IList<Item> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Items.UpdateAsync(items, cancellation);
        }

        public Task<Item> CreateAsync(Item item, CancellationToken cancellation = default(CancellationToken))
        {
            return Items.CreateAsync(item, cancellation);
        }

        public Task<Item> UpdateAsync(Item item, CancellationToken cancellation = default(CancellationToken))
        {
            return Items.UpdateAsync(item, cancellation);
        }

        #endregion

        #region LinkedTransactions

        public Task<IList<LinkedTransaction>> CreateAsync(IList<LinkedTransaction> items, CancellationToken cancellation = default(CancellationToken))
        {
            return LinkedTransactions.CreateAsync(items, cancellation);
        }

        public Task<IList<LinkedTransaction>> UpdateAsync(IList<LinkedTransaction> items, CancellationToken cancellation = default(CancellationToken))
        {
            return LinkedTransactions.UpdateAsync(items, cancellation);
        }

        public Task<LinkedTransaction> CreateAsync(LinkedTransaction item, CancellationToken cancellation = default(CancellationToken))
        {
            return LinkedTransactions.CreateAsync(item, cancellation);
        }

        public Task<LinkedTransaction> UpdateAsync(LinkedTransaction item, CancellationToken cancellation = default(CancellationToken))
        {
            return LinkedTransactions.UpdateAsync(item, cancellation);
        }

        #endregion

        #region ManualJournals

        public Task<IList<ManualJournal>> CreateAsync(IList<ManualJournal> items, CancellationToken cancellation = default(CancellationToken))
        {
            return ManualJournals.CreateAsync(items, cancellation);
        }

        public Task<IList<ManualJournal>> UpdateAsync(IList<ManualJournal> items, CancellationToken cancellation = default(CancellationToken))
        {
            return ManualJournals.UpdateAsync(items, cancellation);
        }

        public Task<ManualJournal> CreateAsync(ManualJournal item, CancellationToken cancellation = default(CancellationToken))
        {
            return ManualJournals.CreateAsync(item, cancellation);
        }

        public Task<ManualJournal> UpdateAsync(ManualJournal item, CancellationToken cancellation = default(CancellationToken))
        {
            return ManualJournals.UpdateAsync(item, cancellation);
        }

        #endregion

        #region Payments

        public Task<IList<Payment>> CreateAsync(IList<Payment> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Payments.CreateAsync(items, cancellation);
        }

        public Task<IList<Payment>> UpdateAsync(IList<Payment> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Payments.UpdateAsync(items, cancellation);
        }

        public Task<Payment> CreateAsync(Payment item, CancellationToken cancellation = default(CancellationToken))
        {
            return Payments.CreateAsync(item, cancellation);
        }

        public Task<Payment> UpdateAsync(Payment item, CancellationToken cancellation = default(CancellationToken))
        {
            return Payments.UpdateAsync(item, cancellation);
        }

        #endregion

        #region PurchaseOrders

        public Task<IList<PurchaseOrder>> CreateAsync(IList<PurchaseOrder> items, CancellationToken cancellation = default(CancellationToken))
        {
            return PurchaseOrders.CreateAsync(items, cancellation);
        }

        public Task<IList<PurchaseOrder>> UpdateAsync(IList<PurchaseOrder> items, CancellationToken cancellation = default(CancellationToken))
        {
            return PurchaseOrders.UpdateAsync(items, cancellation);
        }

        public Task<PurchaseOrder> CreateAsync(PurchaseOrder item, CancellationToken cancellation = default(CancellationToken))
        {
            return PurchaseOrders.CreateAsync(item, cancellation);
        }

        public Task<PurchaseOrder> UpdateAsync(PurchaseOrder item, CancellationToken cancellation = default(CancellationToken))
        {
            return PurchaseOrders.UpdateAsync(item, cancellation);
        }

        #endregion

        #region Receipts

        public Task<IList<Receipt>> CreateAsync(IList<Receipt> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Receipts.CreateAsync(items, cancellation);
        }

        public Task<IList<Receipt>> UpdateAsync(IList<Receipt> items, CancellationToken cancellation = default(CancellationToken))
        {
            return Receipts.UpdateAsync(items, cancellation);
        }

        public Task<Receipt> CreateAsync(Receipt item, CancellationToken cancellation = default(CancellationToken))
        {
            return Receipts.CreateAsync(item, cancellation);
        }

        public Task<Receipt> UpdateAsync(Receipt item, CancellationToken cancellation = default(CancellationToken))
        {
            return Receipts.UpdateAsync(item, cancellation);
        }

        #endregion

        #region Setups

        public Task<ImportSummary> CreateAsync(Setup item, CancellationToken cancellation = default(CancellationToken))
        {
            return Setup.CreateAsync(item, cancellation);
        }

        public Task<ImportSummary> UpdateAsync(Setup item, CancellationToken cancellation = default(CancellationToken))
        {
            return Setup.UpdateAsync(item, cancellation);
        }

        #endregion

        #region TaxRates

        public Task<IList<TaxRate>> CreateAsync(IList<TaxRate> items, CancellationToken cancellation = default(CancellationToken))
        {
            return TaxRates.CreateAsync(items, cancellation);
        }

        public Task<IList<TaxRate>> UpdateAsync(IList<TaxRate> items, CancellationToken cancellation = default(CancellationToken))
        {
            return TaxRates.UpdateAsync(items, cancellation);
        }

        public Task<TaxRate> CreateAsync(TaxRate item, CancellationToken cancellation = default(CancellationToken))
        {
            return TaxRates.CreateAsync(item, cancellation);
        }

        public Task<TaxRate> UpdateAsync(TaxRate item, CancellationToken cancellation = default(CancellationToken))
        {
            return TaxRates.UpdateAsync(item, cancellation);
        }

        #endregion

        #region TrackingCategories

        public Task<IList<TrackingCategory>> CreateAsync(IList<TrackingCategory> items, CancellationToken cancellation = default(CancellationToken))
        {
            return TrackingCategories.CreateAsync(items, cancellation);
        }

        public Task<IList<TrackingCategory>> UpdateAsync(IList<TrackingCategory> items, CancellationToken cancellation = default(CancellationToken))
        {
            return TrackingCategories.UpdateAsync(items, cancellation);
        }

        public Task<TrackingCategory> CreateAsync(TrackingCategory item, CancellationToken cancellation = default(CancellationToken))
        {
            return TrackingCategories.CreateAsync(item, cancellation);
        }

        public Task<TrackingCategory> UpdateAsync(TrackingCategory item, CancellationToken cancellation = default(CancellationToken))
        {
            return TrackingCategories.UpdateAsync(item, cancellation);
        }

        #endregion
    }
}
