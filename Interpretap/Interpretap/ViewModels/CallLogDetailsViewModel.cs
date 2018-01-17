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
    class CallLogDetailsViewModel : BaseViewModel
    {
        private ObservableCollection<FifteenCallModel> _callLogs;
        public ObservableCollection<FifteenCallModel> CallLogs
        {
            get { return _callLogs; }
            set { _callLogs = value; INotifyPropertyChanged(); }
        }

        public AgencyModel Agency { get; set; }
        public BusinessModel Business { get; set; }

        public CallLogDetailsViewModel()
        {
            _callLogs = new ObservableCollection<FifteenCallModel>();
        }

        public async Task LoadData(String fromDate, String minDay, String maxDay, UserTypes userType)
        {
            var fifteenCallsRequestModel = new FifteenCallsRequestModel();
            fifteenCallsRequestModel.FromDate = fromDate;
            fifteenCallsRequestModel.MinDay = minDay;
            fifteenCallsRequestModel.MaxDay = maxDay;
            FetchFifteenCallsRespnse response = null;
            FetchFifteenCallsABResponse ABresponse = null;
            switch (userType)
            {
                case UserTypes.Interpreter:
                    InterpreterService interpreterService = new InterpreterService();
                    response = await interpreterService.FetchFifteenCalls(fifteenCallsRequestModel);
                    break;

                case UserTypes.Client:
                    ClientService clientService = new ClientService();
                    response = await clientService.FetchFifteenCalls(fifteenCallsRequestModel);
                    break;

                case UserTypes.Business:
                    BusinessService businessService = new BusinessService();
                    if (Business != null)
                    {
                        fifteenCallsRequestModel.ClientBusinessId = int.Parse(Business.ClientBusinessId);
                    }
                    else
                    {
                        fifteenCallsRequestModel.ClientBusinessId = LocalStorage.LoginResponseLS.UserInfo.ClientInfo.Businesses.Last().ClientBusinessId; 
                    }
                    ABresponse = await businessService.FetchFifteenCalls(fifteenCallsRequestModel);
                    break;

                case UserTypes.Agency:
                    AgencyService agencyService = new AgencyService();
                    if (Agency != null)
                    {
                        fifteenCallsRequestModel.AgencyId = int.Parse(Agency.InterpreterBusinessId);
                    }
                    else
                    {
                        fifteenCallsRequestModel.AgencyId = LocalStorage.LoginResponseLS.UserInfo.InterpreterInfo.Agencies.Last().InterpreterBusinessId;
                    }
                    ABresponse = await agencyService.FetchFifteenCalls(fifteenCallsRequestModel);
                    break;
            }
            if (response != null)
                foreach (var call in response.Calls)
                    CallLogs.Add(call);

            if (ABresponse != null)
                foreach (var call in ABresponse.Call.Calls)
                    CallLogs.Add(call);

        }
    }
}
