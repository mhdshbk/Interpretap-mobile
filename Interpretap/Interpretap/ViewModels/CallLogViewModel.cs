using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interpretap.Common.Constants;

namespace Interpretap.ViewModels
{
    class CallLogViewModel : BaseViewModel
    {
        UserTypes _userType;

        private ObservableCollection<MonthlyCallReportModel> _callLogs;
        public ObservableCollection<MonthlyCallReportModel> CallLogs
        {
            get { return _callLogs; }
            set { _callLogs = value; INotifyPropertyChanged(); }
        }

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                INotifyPropertyChanged();
            }
        }

        public AgencyModel Agency { get; set; }
        public BusinessModel Business { get; set; }

        public CallLogViewModel()
        {
            _callLogs = new ObservableCollection<MonthlyCallReportModel>();
        }

        public async Task LoadData(String fromDate, UserTypes userType)
        {
            IsBusy = true;

            _userType = userType;

            var callLogRequestModel = new CallLogRequestModel();
            callLogRequestModel.FromDate = fromDate;
            FetchCallLogResponse response = null;
            switch (userType)
            {
                case UserTypes.Interpreter:
                    CallService callInterpreterService = new CallService();
                    response = await callInterpreterService.FetchCallLogs(callLogRequestModel);
                    break;

                case UserTypes.Client:
                    CallService callClientService = new CallService();
                    response = await callClientService.FetchCallLogs(callLogRequestModel);
                    break;

                case UserTypes.Business:
                    BusinessService businessService = new BusinessService();
                    if (Business != null)
                    {
                        callLogRequestModel.ClientBusinessId = int.Parse(Business.ClientBusinessId);
                        response = await businessService.FetchCallLogs(callLogRequestModel);
                    }
                    break;

                case UserTypes.Agency:
                    AgencyService agencyService = new AgencyService();
                    if (Agency != null)
                    {
                        callLogRequestModel.AgencyId = int.Parse(Agency.InterpreterBusinessId);
                        response = await agencyService.FetchCallLogs(callLogRequestModel);
                    }
                    break;
            }
            if (response.CallLogs != null)
            {
                foreach (var call in response.CallLogs)
                    CallLogs.Add(call);
            }
            IsBusy = false;
        }

        public async Task OnItemAppearingAsync(MonthlyCallReportModel callModel)
        {
            var itemIsLastVisible = callModel == CallLogs.Last();
            if (itemIsLastVisible)
            {
                // oldest calls are in the bottom - load more oldest calls
                var paginationInitialDateTimeString = callModel.StartOfMonth;
                DateTime paginationInitialDateTime;
                if (DateTime.TryParse(paginationInitialDateTimeString, out paginationInitialDateTime))
                {
                    paginationInitialDateTime = paginationInitialDateTime.AddSeconds(-1);
                    var paginationInitialDateString = paginationInitialDateTime.ToString("yyyy-MM-dd");
                    await LoadData(paginationInitialDateString, _userType);
                }
            }
        }
    }
}
