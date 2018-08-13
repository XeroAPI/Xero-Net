using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Xero.Api.Core.Model.Types
{
    [DataContract(Namespace = "")]
    public enum SourceType
    {
        [EnumMember(Value = "ACCREC")]
        AccountsReceivableInvoice = 1,
        [EnumMember(Value = "ACCPAY")]
        AccountsPayableInvoice = 2,
        [EnumMember(Value = "ACCRECCREDIT")]
        AccountsReceivableCreditNote = 3,
        [EnumMember(Value = "ACCPAYCREDIT")]
        AccountsPayableCreditNote = 4,
        [EnumMember(Value = "ACCRECPAYMENT")]
        PaymentOnAnAccountsReceivableInvoice = 5,
        [EnumMember(Value = "ACCPAYPAYMENT")]
        PaymentOnAnAccountsPayableInvoice = 6,
        [EnumMember(Value = "ARCREDITPAYMENT")]
        AccountsReceivableCreditNotePayment = 7,
        [EnumMember(Value = "APCREDITPAYMENT")]
        AccountsPayableCreditNotePayment = 8,
        [EnumMember(Value = "CASHREC")]
        ReceiveMoneyBankTransaction = 9,
        [EnumMember(Value = "CASHPAID")]
        SpendMoneyBankTransaction = 10,
        [EnumMember(Value = "TRANSFER")]
        BankTransfer = 11,
        [EnumMember(Value = "ARPREPAYMENT")]
        AccountsReceivablePrepayment = 12,
        [EnumMember(Value = "APPREPAYMENT")]
        AccountsPayablePrepayment = 13,
        [EnumMember(Value = "AROVERPAYMENT")]
        AccountsReceivableOverpayment = 14,
        [EnumMember(Value = "APOVERPAYMENT")]
        AccountsPayableOverpayment = 15,
        [EnumMember(Value = "EXPCLAIM")]
        ExpenseClaim = 16,
        [EnumMember(Value = "EXPPAYMENT")]
        ExpenseClaimPayment = 17,
        [EnumMember(Value = "MANJOURNAL")]
        ManualJournal = 18,
        [EnumMember(Value = "PAYSLIP")]
        Payslip = 19,
        [EnumMember(Value = "WAGEPAYABLE")]
        PayrollPayable = 20,
        [EnumMember(Value = "INTEGRATEDPAYROLLPE")]
        PayrollExpense = 21,
        [EnumMember(Value = "INTEGRATEDPAYROLLPT")]
        PayrollPayment = 22,
        [EnumMember(Value = "EXTERNALSPENDMONEY")]
        ExternalSpendMoney = 23,
        [EnumMember(Value = "INTEGRATEDPAYROLLPTPAYMENT")]
        PayrollTaxPayment = 24,
        [EnumMember(Value = "INTEGRATEDPAYROLLCN")]
        PayrollCreditNote = 25,
        [EnumMember(Value = "INTEGRATEDPAYROLLPLL")]
        PayrollLeaveLiability = 26
    }
}
