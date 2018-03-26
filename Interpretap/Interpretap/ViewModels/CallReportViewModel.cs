using Interpretap.Core;
using Interpretap.Interfaces;
using Microcharts;
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

        public Chart ReportChart { get; set; }

        string DateFrom => Report != null ? Report.Report.StartDate.ToString("yyyy-MM-dd") : string.Empty;
        string DateTo => Report != null ? Report.Report.EndDate.ToString("yyyy-MM-dd") : string.Empty;
        public string DateInterval => Report != null ? $"{DateFrom}   TO   {DateTo}" : string.Empty;

        public string TotalCallSeconds => Report != null ? $"{Report.Report.ReportInfo.TotalCallAmountSeconds} seconds" : string.Empty;
        public string TotalPausedSeconds => Report != null ? $"{Report.Report.ReportInfo.TotalPauseAmountSeconds}" : string.Empty;

        long TotalBilledSecondsLong => Report != null ? Report.Report.ReportInfo.TotalCallAmountSeconds - Report.Report.ReportInfo.TotalPauseAmountSeconds : 0;
        public string TotalBilledSeconds => Report != null ? $"{TotalBilledSecondsLong}" : string.Empty;

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

                //Creating PieChart
                var entries = new[]
                {
                    new Entry(TotalBilledSecondsLong)
                    {
                        Color = SkiaSharp.SKColor.Parse("#f37a3f"),
                        //Label = "Billed Seconds",
                        //ValueLabel = TotalBilledSecondsLong.ToString()
                    },
                    new Entry(Report.Report.ReportInfo.TotalPauseAmountSeconds)
                    {
                        Color = SkiaSharp.SKColor.Parse("#2e86c1"),
                        //Label = "Paused Seconds",
                        //ValueLabel = Report.Report.ReportInfo.TotalPauseAmountSeconds.ToString()
                    }
                };

                ReportChart = new PieChart() 
                { 
                    Entries = entries,
                    BackgroundColor = SkiaSharp.SKColor.Parse("#eeeeee")
                };
                //PieChart Creation Completed
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", responce.GetMessage(), "Ok");
            }
            IsLoading = false;
        }
    }
}
