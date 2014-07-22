using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Xero.Api.Common;
using Xero.Api.Core.Model.Reports;
using Xero.Api.Core.Model.Types;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public class ReportsEndpoint : XeroReadEndpoint<ReportsEndpoint, Report, ReportsResponse>
    {
        public ReportsEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/Reports")
        {
        }

        public Report GetPublishedReport(string id)
        {
            return Find(id);
        }

        public Report GetPublishedReport(Guid id)
        {
            return Find(id);
        }

        public IEnumerable<string> Published
        {
            get
            {
                return Find().Select(r => r.ReportID);
            }
        }

        public IEnumerable<string> Named
        {
            get
            {
                return Enum.GetNames(typeof(NamedReportType));
            }
        }

        public Report TenNinetyNine(DateTime? year)
        {
            var parameters = new NameValueCollection();

            parameters.AddYear("reportYear", year);

           AddParameters(parameters);

            return Find(NamedReportType.TenNinetyNine.ToString());
        }

        public Report AgedPayables(Guid contact, DateTime? date = null, DateTime? from = null, DateTime? to = null)
        {
            GetAgedParameters(contact, date, from, to);

            return Find(NamedReportType.AgedPayablesByContact.ToString());
        }

        public Report AgedReceivables(Guid contact, DateTime? date = null, DateTime? from = null, DateTime? to = null)
        {
            GetAgedParameters(contact, date, from, to);

            return Find(NamedReportType.AgedReceivablesByContact.ToString());
        }

        public Report BalanceSheet(DateTime date, Guid? tracking1 = null, Guid? tracking2 = null,
            bool standardLayout = false)
        {
            var parameters = new NameValueCollection();

            parameters.Add("date", date);
            parameters.Add("trackingOptionID1", tracking1);
            parameters.Add("trackingOptionID2", tracking2);
            parameters.Add("standardLayout", standardLayout);

            AddParameters(parameters);

            return Find(NamedReportType.BalanceSheet.ToString());
        }

        public Report BankStatement(Guid account, DateTime? from = null, DateTime? to = null)
        {
            var parameters = new NameValueCollection();

            parameters.Add("bankAccountID", account);
            parameters.Add("fromDate", from);
            parameters.Add("toDate", to);

            AddParameters(parameters);

            return Find(NamedReportType.BankStatement.ToString());
        }

        public Report BankSummary(DateTime? from = null, DateTime? to = null)
        {
            var parameters = new NameValueCollection();

            parameters.Add("fromDate", from);
            parameters.Add("toDate", to);

            AddParameters(parameters);

            return Find(NamedReportType.BankSummary.ToString());
        }

        public Report BudgetSummary(DateTime? date = null, int? periods = null, BudgetSummaryTimeframeType? timeFrame = null)
        {
            var parameters = new NameValueCollection();

            parameters.Add("date", date);
            parameters.Add("periods", periods);
            parameters.Add("timeframe", (int?)timeFrame);

            AddParameters(parameters);

            return Find(NamedReportType.BudgetSummary.ToString());
        }

        public Report ExecutiveSummary(DateTime? date = null)
        {
            var parameters = new NameValueCollection();

            parameters.Add("date", date);

            AddParameters(parameters);

            return Find(NamedReportType.ExecutiveSummary.ToString());
        }

        public Report ProfitAndLoss(DateTime? date, DateTime? from = null, DateTime? to = null,
            Guid? trackingCategory = null, Guid? trackingOption = null, bool? standardLayout = null)
        {
            var parameters = new NameValueCollection();

            parameters.Add("date", date);
            parameters.Add("fromDate", from);
            parameters.Add("toDate", to);
            parameters.Add("trackingCategoryID", trackingCategory);
            parameters.Add("trackingOptionID", trackingOption);
            parameters.Add("standardLayout", standardLayout);

            AddParameters(parameters);

            return Find(NamedReportType.ProfitAndLoss.ToString());
        }

        public Report TrailBalance(DateTime? date = null, bool? paymentsOnly = null)
        {
            var parameters = new NameValueCollection();

            parameters.Add("date", date);
            parameters.Add("paymentsOnly", paymentsOnly);

            AddParameters(parameters);

            return Find(NamedReportType.TrialBalance.ToString());
        }

        private void GetAgedParameters(Guid contact, DateTime? date, DateTime? from, DateTime? to)
        {
            var parameters = new NameValueCollection
            {
                {
                    "contactID", contact.ToString("D")
                }
            };

            parameters.Add("date", date);
            parameters.Add("fromDate", from);
            parameters.Add("toDate", to);

            AddParameters(parameters);
        }
    }

    internal static class Extensions
    {
        public static string ToReportDate(this DateTime dt)
        {
            return dt.ToString("dd MMM yyyy");
        }

        public static void AddYear(this NameValueCollection collection, string name, DateTime? value)
        {
            if (value.HasValue)
            {
                collection.Add(name, value.Value.Year);
            }
        }

        public static void Add(this NameValueCollection collection, string name, DateTime? value)
        {
            if (value.HasValue)
            {
                collection.Add(name, value.Value.ToReportDate());
            }
        }
    }
}
