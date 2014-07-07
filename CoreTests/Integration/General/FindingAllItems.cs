using NUnit.Framework;

namespace CoreTests.Integration.General
{
    [TestFixture]
    public class FindingAllItems : ApiWrapperTest
    {
        [Test]
        public void get_accounts()
        {
            Assert.DoesNotThrow(() => Api.Accounts.Find());
        }

        [Test]
        public void get_bank_transactions()
        {
            Assert.DoesNotThrow(() => Api.BankTransactions.Find());
        }

        [Test]
        public void get_bank_transfers()
        {
            Assert.DoesNotThrow(() => Api.BankTransfers.Find());
        }

        [Test]
        public void get_branding_themes()
        {
            Assert.DoesNotThrow(() => Api.BrandingThemes.Find());
        }

        [Test]
        public void get_contacts()
        {
            Assert.DoesNotThrow(() => Api.Contacts.Find());
        }

        [Test]
        public void get_credit_notes()
        {
            Assert.DoesNotThrow(() => Api.CreditNotes.Find());
        }

        [Test]
        public void get_currencies()
        {
            Assert.DoesNotThrow(() => Api.Currencies.Find());
        }

        [Test]
        public void get_employees()
        {
            Assert.DoesNotThrow(() => Api.Employees.Find());
        }

        [Test]
        public void get_expense_claims()
        {
            Assert.DoesNotThrow(() => Api.ExpenseClaims.Find());
        }

        [Test]
        public void get_invoices()
        {
            Assert.DoesNotThrow(() => Api.Invoices.Find());
        }

        [Test]
        public void get_items()
        {
            Assert.DoesNotThrow(() => Api.Items.Find());
        }

        [Test]
        public void get_journals()
        {
            Assert.DoesNotThrow(() => Api.Journals.Find());
        }

        [Test]
        public void get_manual_journals()
        {
            Assert.DoesNotThrow(() => Api.ManualJournals.Find());
        }

        [Test]
        public void get_payments()
        {
            Assert.DoesNotThrow(() => Api.Payments.Find());
        }

        [Test]
        public void get_receipts()
        {
            Assert.DoesNotThrow(() => Api.Receipts.Find());
        }

        [Test]
        public void get_repeating_invoices()
        {
            Assert.DoesNotThrow(() => Api.RepeatingInvoices.Find());
        }

        [Test]
        public void get_tax_rates()
        {
            Assert.DoesNotThrow(() => Api.TaxRates.Find());
        }

        [Test]
        public void get_tracking_categories()
        {
            Assert.DoesNotThrow(() => Api.TrackingCategories.Find());
        }

        [Test]
        public void get_users()
        {
            Assert.DoesNotThrow(() => Api.Users.Find());
        }        
    }
}
