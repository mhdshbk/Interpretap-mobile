using Interpretap.Core;
using Interpretap.Interfaces;
using PropertyChanged;
using System.Threading.Tasks;
using static Interpretap.Common.Constants;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CallReportViewModel
    {
        ICallReportModel ReportModel { get; set; }
        ICallReportResponce Report { get; set; }

        string DateFrom => Report != null ? Report.Report.StartDate.ToString("yyyy-MM-dd") : string.Empty;
        string DateTo => Report != null ? Report.Report.EndDate.ToString("yyyy-MM-dd") : string.Empty;
        public string DateInterval => Report != null ? $"{DateFrom} to {DateTo}" : string.Empty;

        public string TotalCallSeconds => Report != null ? $"{Report.Report.ReportInfo.TotalCallAmountSeconds} seconds" : string.Empty;
        public string TotalPausedSeconds => Report != null ? $"{Report.Report.ReportInfo.TotalPauseAmountSeconds} seconds" : string.Empty;

        long TotalBilledSecondsLong => Report != null ? Report.Report.ReportInfo.TotalCallAmountSeconds - Report.Report.ReportInfo.TotalPauseAmountSeconds : 0;
        public string TotalBilledSeconds => Report != null ? $"{TotalBilledSecondsLong} seconds" : string.Empty;

        public bool IsLoading { get; set; }

        public CallReportViewModel(string dateFrom, string dateTo, UserTypes userType)
        {
            if (userType == UserTypes.Client)
            {
                ReportModel = new ClientCallReportModel();
            }
            if (userType == UserTypes.Interpreter)
            {
                ReportModel = new InterpreterCallReportModel();
            }
            GetReportAsync(dateFrom, dateTo);
        }

        async Task GetReportAsync(string dateFrom, string dateTo)
        {
            IsLoading = true;
            var responce = await ReportModel.FetchReport(dateFrom, dateTo);
            var success = responce.Status == true;
            if (success)
            {
                Report = responce;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", responce.Message, "Ok");
            }
            IsLoading = false;
        }
    }
}
