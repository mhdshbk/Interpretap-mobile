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
            switch (userType)
            {
                case UserTypes.Interpreter:
                    InterpreterService interpreterService = new InterpreterService();
                    response = await interpreterService.FetchFifteenCalls(fifteenCallsRequestModel);
                    break;

                //case UserTypes.Client:
                //    InterpreterService interpreterService = new InterpreterService();
                //    response = await interpreterService.FetchFifteenCalls(fifteenCallsRequestModel);
                //    break;

                //case UserTypes.Business:
                //    InterpreterService interpreterService = new InterpreterService();
                //    response = await interpreterService.FetchFifteenCalls(fifteenCallsRequestModel);
                //    break;

                //case UserTypes.Agency:
                //    InterpreterService interpreterService = new InterpreterService();
                //    response = await interpreterService.FetchFifteenCalls(fifteenCallsRequestModel);
                //    break;
            }
            if(response != null)
            foreach (var call in response.Calls)
                CallLogs.Add(call);

        }
    }
}
