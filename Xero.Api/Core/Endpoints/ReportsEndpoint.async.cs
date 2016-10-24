using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Common;
using Xero.Api.Core.Model.Reports;
using Xero.Api.Core.Model.Types;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial interface IReportsEndpoint : IAsyncXeroReadEndpoint<ReportsEndpoint, Report, ReportsResponse>
    {
        Task<Report> GetPublishedReportAsync(string id, CancellationToken cancellation = default(CancellationToken));
        Task<Report> GetPublishedReportAsync(Guid id, CancellationToken cancellation = default(CancellationToken));
        Task<IList<string>> GetPublishedAsync(CancellationToken cancellation = default(CancellationToken));
        Task<Report> AgedPayablesAsync(Guid contact, DateTime? date = null, DateTime? from = null, DateTime? to = null, CancellationToken cancellation = default(CancellationToken));
        Task<Report> AgedReceivablesAsync(Guid contact, DateTime? date = null, DateTime? from = null, DateTime? to = null, CancellationToken cancellation = default(CancellationToken));
        Task<Report> TenNinetyNineAsync(DateTime? year, CancellationToken cancellation = default(CancellationToken));
        Task<Report> BalanceSheetAsync(DateTime date, Guid? tracking1 = null, Guid? tracking2 = null,
            bool standardLayout = false, CancellationToken cancellation = default(CancellationToken));
        Task<Report> BankStatementAsync(Guid account, DateTime? from = null, DateTime? to = null, CancellationToken cancellation = default(CancellationToken));
        Task<Report> BankSummaryAsync(DateTime? from = null, DateTime? to = null, CancellationToken cancellation = default(CancellationToken));
        Task<Report> BudgetSummaryAsync(DateTime? date = null, int? periods = null, BudgetSummaryTimeframeType? timeFrame = null, CancellationToken cancellation = default(CancellationToken));
        Task<Report> ExecutiveSummaryAsync(DateTime? date = null, CancellationToken cancellation = default(CancellationToken));
        Task<Report> ProfitAndLossAsync(DateTime? date, DateTime? from = null, DateTime? to = null,
            Guid? trackingCategory = null, Guid? trackingOption = null, Guid? trackingCategory2 = null,
            Guid? trackingOption2 = null, bool? standardLayout = null, CancellationToken cancellation = default(CancellationToken));
        Task<Report> TrailBalanceAsync(DateTime? date = null, bool? paymentsOnly = null, CancellationToken cancellation = default(CancellationToken));
    }

    public partial class ReportsEndpoint : XeroReadEndpoint<ReportsEndpoint, Report, ReportsResponse>, IReportsEndpoint
    {
        public Task<Report> GetPublishedReportAsync(string id, CancellationToken cancellation = default(CancellationToken))
        {
            return FindAsync(id, cancellation);
        }

        public Task<Report> GetPublishedReportAsync(Guid id, CancellationToken cancellation = default(CancellationToken))
        {
            return FindAsync(id, cancellation);
        }

        public async Task<IList<string>> GetPublishedAsync(CancellationToken cancellation = default(CancellationToken))
        {
            return (await FindAsync(cancellation)).Select(r => r.ReportID).ToList();
        }

        public Task<Report> TenNinetyNineAsync(DateTime? year, CancellationToken cancellation = default(CancellationToken))
        {
            var parameters = new NameValueCollection();

            parameters.AddYear("reportYear", year);

            AddParameters(parameters);

            return FindAsync(NamedReportType.TenNinetyNine.ToString(), cancellation);
        }

        public Task<Report> AgedPayablesAsync(Guid contact, DateTime? date = null, DateTime? from = null, DateTime? to = null, CancellationToken cancellation = default(CancellationToken))
        {
            GetAgedParameters(contact, date, from, to);

            return FindAsync(NamedReportType.AgedPayablesByContact.ToString(), cancellation);
        }

        public Task<Report> AgedReceivablesAsync(Guid contact, DateTime? date = null, DateTime? from = null, DateTime? to = null, CancellationToken cancellation = default(CancellationToken))
        {
            GetAgedParameters(contact, date, from, to);

            return FindAsync(NamedReportType.AgedReceivablesByContact.ToString(), cancellation);
        }

        public Task<Report> BalanceSheetAsync(DateTime date, Guid? tracking1 = null, Guid? tracking2 = null,
            bool standardLayout = false, CancellationToken cancellation = default(CancellationToken))
        {
            var parameters = new NameValueCollection();

            parameters.Add("date", date);
            parameters.Add("trackingOptionID1", tracking1);
            parameters.Add("trackingOptionID2", tracking2);
            parameters.Add("standardLayout", standardLayout);

            AddParameters(parameters);

            return FindAsync(NamedReportType.BalanceSheet.ToString(), cancellation);
        }

        public Task<Report> BankStatementAsync(Guid account, DateTime? from = null, DateTime? to = null, CancellationToken cancellation = default(CancellationToken))
        {
            var parameters = new NameValueCollection();

            parameters.Add("bankAccountID", account);
            parameters.Add("fromDate", from);
            parameters.Add("toDate", to);

            AddParameters(parameters);

            return FindAsync(NamedReportType.BankStatement.ToString(), cancellation);
        }

        public Task<Report> BankSummaryAsync(DateTime? from = null, DateTime? to = null, CancellationToken cancellation = default(CancellationToken))
        {
            var parameters = new NameValueCollection();

            parameters.Add("fromDate", from);
            parameters.Add("toDate", to);

            AddParameters(parameters);

            return FindAsync(NamedReportType.BankSummary.ToString(), cancellation);
        }

        public Task<Report> BudgetSummaryAsync(DateTime? date = null, int? periods = null, BudgetSummaryTimeframeType? timeFrame = null, CancellationToken cancellation = default(CancellationToken))
        {
            var parameters = new NameValueCollection();

            parameters.Add("date", date);
            parameters.Add("periods", periods);
            parameters.Add("timeframe", (int?)timeFrame);

            AddParameters(parameters);

            return FindAsync(NamedReportType.BudgetSummary.ToString(), cancellation);
        }

        public Task<Report> ExecutiveSummaryAsync(DateTime? date = null, CancellationToken cancellation = default(CancellationToken))
        {
            var parameters = new NameValueCollection();

            parameters.Add("date", date);

            AddParameters(parameters);

            return FindAsync(NamedReportType.ExecutiveSummary.ToString(), cancellation);
        }

        public Task<Report> ProfitAndLossAsync(DateTime? date, DateTime? from = null, DateTime? to = null,
            Guid? trackingCategory = null, Guid? trackingOption = null, Guid? trackingCategory2 = null,
            Guid? trackingOption2 = null, bool? standardLayout = null, CancellationToken cancellation = default(CancellationToken))
        {
            var parameters = new NameValueCollection();

            parameters.Add("date", date);
            parameters.Add("fromDate", from);
            parameters.Add("toDate", to);
            parameters.Add("trackingCategoryID", trackingCategory);
            parameters.Add("trackingOptionID", trackingOption);
            parameters.Add("trackingCategoryID2", trackingCategory2);
            parameters.Add("trackingOptionID2", trackingOption2);
            parameters.Add("standardLayout", standardLayout);

            AddParameters(parameters);

            return FindAsync(NamedReportType.ProfitAndLoss.ToString(), cancellation);
        }

        public Task<Report> TrailBalanceAsync(DateTime? date = null, bool? paymentsOnly = null, CancellationToken cancellation = default(CancellationToken))
        {
            var parameters = new NameValueCollection();

            parameters.Add("date", date);
            parameters.Add("paymentsOnly", paymentsOnly);

            AddParameters(parameters);

            return FindAsync(NamedReportType.TrialBalance.ToString(), cancellation);
        }
    }    
}
