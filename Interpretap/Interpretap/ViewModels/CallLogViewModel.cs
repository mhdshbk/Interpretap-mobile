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

        public AssosiateAgencies Agency { get; set; }
        public AssosiateBusiness Business { get; set; }

        public CallLogViewModel()
        {
            _callLogs = new ObservableCollection<MonthlyCallReportModel>();
        }

        public async Task LoadData(String fromDate, UserTypes userType)
        {
            IsBusy = true;
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
                        callLogRequestModel.ClientBusinessId = Business.ClientBusinessId;
                    }
                    else
                    {
                        callLogRequestModel.ClientBusinessId = LocalStorage.LoginResponseLS.UserInfo.ClientInfo.Businesses.Last().ClientBusinessId;
                    }
                    response = await businessService.FetchCallLogs(callLogRequestModel);
                    break;

                case UserTypes.Agency:
                    AgencyService agencyService = new AgencyService();
                    if (Agency != null)
                    {
                        callLogRequestModel.AgencyId = Agency.InterpreterBusinessId;
                    }
                    else
                    {
                        callLogRequestModel.AgencyId = LocalStorage.LoginResponseLS.UserInfo.InterpreterInfo.Agencies.Last().InterpreterBusinessId;
                    }
                    response = await agencyService.FetchCallLogs(callLogRequestModel);
                    break;
            }
            if (response.CallLogs != null)
            {
                foreach (var call in response.CallLogs)
                    CallLogs.Add(call);
            }
            IsBusy = false;
        }
    }
}
