using System;
using System.Linq;
using System.Runtime.Serialization;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.ThirdParty.ServiceStack.Text;
using Xero.Api.Payroll.America.Model.Types;
using Xero.Api.Payroll.Australia.Model.Status;
using Xero.Api.Payroll.Australia.Model.Types;
using Xero.Api.Payroll.Common.Model.Status;

namespace Xero.Api.Serialization
{
    public class DefaultMapper : IJsonObjectMapper, IXmlObjectMapper
    {
        public DefaultMapper()
        {
            BuildEnumList();
        }

        T IJsonObjectMapper.From<T>(string result)
        {
            var item = JsonSerializer.DeserializeFromString<T>(result);
            return item;
        }

        string IJsonObjectMapper.To<T>(T request)
        {
            var json = JsonSerializer.SerializeToString(request);
            return json;
        }

        T IXmlObjectMapper.From<T>(string result)
        {
            var item = XmlSerializer.DeserializeFromString<T>(result);
            return item;
        }

        string IXmlObjectMapper.To<T>(T request)
        {
            string xml = XmlSerializer.SerializeToString(request);
            return xml;
        }

        private void BuildEnumList()
        {
            BuildCore();
            BuildPayroll();
        }

        private void BuildPayroll()
        {
            JsConfig<PayRunStatus>.DeSerializeFn = EnumDeserializer<PayRunStatus>;

            BuildAmericanPayroll();
            BuildAustralianPayroll();
        }

        private void BuildCore()
        {
            JsConfig<AccountStatus>.DeSerializeFn = EnumDeserializer<AccountStatus>;
            JsConfig<BankTransactionStatus>.DeSerializeFn = EnumDeserializer<BankTransactionStatus>;
            JsConfig<ContactStatus>.DeSerializeFn = EnumDeserializer<ContactStatus>;
            JsConfig<EmployeeStatus>.DeSerializeFn = EnumDeserializer<EmployeeStatus>;
            JsConfig<ExpenseClaimStatus>.DeSerializeFn = EnumDeserializer<ExpenseClaimStatus>;
            JsConfig<InvoiceStatus>.DeSerializeFn = EnumDeserializer<InvoiceStatus>;
            JsConfig<ManualJournalStatus>.DeSerializeFn = EnumDeserializer<ManualJournalStatus>;
            JsConfig<OrganisationStatus>.DeSerializeFn = EnumDeserializer<OrganisationStatus>;
            JsConfig<PaymentStatus>.DeSerializeFn = EnumDeserializer<PaymentStatus>;
            JsConfig<ReceiptStatus>.DeSerializeFn = EnumDeserializer<ReceiptStatus>;
            JsConfig<TaxRateStatus>.DeSerializeFn = EnumDeserializer<TaxRateStatus>;
            JsConfig<TrackingCategoryStatus>.DeSerializeFn = EnumDeserializer<TrackingCategoryStatus>;

            JsConfig<AccountClassType>.DeSerializeFn = EnumDeserializer<AccountClassType>;
            JsConfig<Core.Model.Types.AccountType>.DeSerializeFn = EnumDeserializer<Core.Model.Types.AccountType>;
            JsConfig<AddressType>.DeSerializeFn = EnumDeserializer<AddressType>;
            JsConfig<BankTransactionType>.DeSerializeFn = EnumDeserializer<BankTransactionType>;
            JsConfig<CreditNoteType>.DeSerializeFn = EnumDeserializer<CreditNoteType>;
            JsConfig<InvoiceType>.DeSerializeFn = EnumDeserializer<InvoiceType>;
            JsConfig<OrganisationType>.DeSerializeFn = EnumDeserializer<OrganisationType>;
            JsConfig<OrganisationVersion>.DeSerializeFn = EnumDeserializer<OrganisationVersion>;
            JsConfig<PaymentTermType>.DeSerializeFn = EnumDeserializer<PaymentTermType>;
            JsConfig<PaymentType>.DeSerializeFn = EnumDeserializer<PaymentType>;
            JsConfig<PhoneType>.DeSerializeFn = EnumDeserializer<PhoneType>;
            JsConfig<ReportTaxType>.DeSerializeFn = EnumDeserializer<ReportTaxType>;
            JsConfig<SystemAccountType>.DeSerializeFn = EnumDeserializer<SystemAccountType>;
            JsConfig<Core.Model.Types.UnitType>.DeSerializeFn = EnumDeserializer<Core.Model.Types.UnitType>;
            JsConfig<UserRole>.DeSerializeFn = EnumDeserializer<UserRole>;
        }

        private void BuildAmericanPayroll()
        {
            JsConfig<Payroll.America.Model.Types.AccountType>.DeSerializeFn = EnumDeserializer<Payroll.America.Model.Types.AccountType>;
            JsConfig<BenefitCategoryType>.DeSerializeFn = EnumDeserializer<BenefitCategoryType>;
            JsConfig<CalculationType>.DeSerializeFn = EnumDeserializer<CalculationType>;
            JsConfig<DeductionCategoryType>.DeSerializeFn = EnumDeserializer<DeductionCategoryType>;
            JsConfig<EarningsCategoryType>.DeSerializeFn = EnumDeserializer<EarningsCategoryType>;
            JsConfig<Payroll.America.Model.Types.EmploymentBasisType>.DeSerializeFn = EnumDeserializer<Payroll.America.Model.Types.EmploymentBasisType>;
            JsConfig<PaymentMethodType>.DeSerializeFn = EnumDeserializer<PaymentMethodType>;
            JsConfig<Payroll.America.Model.Types.RateType>.DeSerializeFn = EnumDeserializer<Payroll.America.Model.Types.RateType>;
            JsConfig<Payroll.America.Model.Types.State>.DeSerializeFn = EnumDeserializer<Payroll.America.Model.Types.State>;
            JsConfig<SalaryWagesType>.DeSerializeFn = EnumDeserializer<SalaryWagesType>;
            JsConfig<ScheduleType>.DeSerializeFn = EnumDeserializer<ScheduleType>;
            JsConfig<TimeOffCategoryType>.DeSerializeFn = EnumDeserializer<TimeOffCategoryType>;
            JsConfig<Payroll.America.Model.Types.UnitType>.DeSerializeFn = EnumDeserializer<Payroll.America.Model.Types.UnitType>;
        }

        private void BuildAustralianPayroll()
        {
            JsConfig<EmploymentStatus>.DeSerializeFn = EnumDeserializer<EmploymentStatus>;
            JsConfig<LeavePeriodStatus>.DeSerializeFn = EnumDeserializer<LeavePeriodStatus>;
            JsConfig<TimesheetStatus>.DeSerializeFn = EnumDeserializer<TimesheetStatus>;

            JsConfig<CalendarType>.DeSerializeFn = EnumDeserializer<CalendarType>;
            JsConfig<DeductionCalculationType>.DeSerializeFn = EnumDeserializer<DeductionCalculationType>;
            JsConfig<EarningsRateCalculationType>.DeSerializeFn = EnumDeserializer<EarningsRateCalculationType>;
            JsConfig<Payroll.Australia.Model.Types.EmploymentBasisType>.DeSerializeFn = EnumDeserializer<Payroll.Australia.Model.Types.EmploymentBasisType>;
            JsConfig<LeaveCalculationType>.DeSerializeFn = EnumDeserializer<LeaveCalculationType>;
            JsConfig<LeaveContributionType>.DeSerializeFn = EnumDeserializer<LeaveContributionType>;
            JsConfig<PaymentFrequencyType>.DeSerializeFn = EnumDeserializer<PaymentFrequencyType>;
            JsConfig<Payroll.Australia.Model.Types.RateType>.DeSerializeFn = EnumDeserializer<Payroll.Australia.Model.Types.RateType>;
            JsConfig<Payroll.Australia.Model.Types.State>.DeSerializeFn = EnumDeserializer<Payroll.Australia.Model.Types.State>;
            JsConfig<SuperannuationCalculationType>.DeSerializeFn = EnumDeserializer<SuperannuationCalculationType>;
            JsConfig<SuperannuationContributionType>.DeSerializeFn = EnumDeserializer<SuperannuationContributionType>;
            JsConfig<SuperfundType>.DeSerializeFn = EnumDeserializer<SuperfundType>;
            JsConfig<TaxFileNumberExemptionType>.DeSerializeFn = EnumDeserializer<TaxFileNumberExemptionType>;
        }

        private TEnum EnumDeserializer<TEnum>(string s)
            where TEnum : struct
        {
            TEnum t;

            // If all goes well then we are done
            if (Enum.TryParse(s, out t))
                return t;
            
            // get the EnumMember attribute and see if the Value attribute matches the string
            foreach (var p in t.GetType().GetMembers())
            {
                var attributes = p.GetCustomAttributes(typeof (EnumMemberAttribute), false).Cast<EnumMemberAttribute>();
                if (attributes.All(a => String.Compare(a.Value, s, StringComparison.OrdinalIgnoreCase) != 0))
                    continue;
                Enum.TryParse(p.Name, out t);
            }

            return t;
        }        
    }    
}