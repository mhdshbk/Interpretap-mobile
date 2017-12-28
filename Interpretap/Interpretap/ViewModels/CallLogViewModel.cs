using Interpretap.Models;
using Interpretap.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.ViewModels
{
    class CallLogViewModel : BaseViewModel
    {
        private ObservableCollection<MonthlyCallReportModel> _callLogs;
        public ObservableCollection<MonthlyCallReportModel> CallLogs
        {
            get { return _callLogs; }
            set { _callLogs = value; INotifyPropertyChanged(); }
        }

        public CallLogViewModel()
        {
            _callLogs = new ObservableCollection<MonthlyCallReportModel>();
        }

        public async Task LoadData(String fromDate)
        {
            CallService _interpreterService = new CallService();
            var callLogRequestModel = new CallLogRequestModel();
            callLogRequestModel.FromDate = fromDate;
            var callResponse = await _interpreterService.FetchCallLogs(callLogRequestModel);
            foreach (var call in callResponse.CallLogs)
                CallLogs.Add(call);
        }
    }
}
