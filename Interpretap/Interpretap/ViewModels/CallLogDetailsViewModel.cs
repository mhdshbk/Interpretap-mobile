using Interpretap.Models;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using static Interpretap.Common.Constants;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class CallLogDetailsViewModel : BaseViewModel
    {
        String _minDay;
        String _maxDay;
        UserTypes _userType;

        private ObservableCollection<FifteenCallModel> _callLogs;
        public ObservableCollection<FifteenCallModel> CallLogs
        {
            get { return _callLogs; }
            set { _callLogs = value; INotifyPropertyChanged(); }
        }

        public AgencyModel Agency { get; set; }
        public BusinessModel Business { get; set; }

        public bool IsLoading { get; set; }

        public CallLogDetailsViewModel()
        {
            _callLogs = new ObservableCollection<FifteenCallModel>();
        }

        public async Task LoadData(String fromDate, String minDay, String maxDay, UserTypes userType)
        {
            IsLoading = true;

            _minDay = minDay;
            _maxDay = maxDay;
            _userType = userType;

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
                        ABresponse = await businessService.FetchFifteenCalls(fifteenCallsRequestModel);
                    }
                    break;

                case UserTypes.Agency:
                    AgencyService agencyService = new AgencyService();
                    if (Agency != null)
                    {
                        fifteenCallsRequestModel.AgencyId = int.Parse(Agency.InterpreterBusinessId);
                        ABresponse = await agencyService.FetchFifteenCalls(fifteenCallsRequestModel);
                    }
                    break;
            }
            if (response != null)
                foreach (var call in response.Calls)
                    CallLogs.Add(call);
                

            if (ABresponse != null && ABresponse.Call != null)
                foreach (var call in ABresponse.Call.Calls)
                    CallLogs.Add(call);
            IsLoading = false;
        }

        public async Task OnItemAppearingAsync(FifteenCallModel callModel)
        {
            var itemIsLastVisible = callModel == CallLogs.Last();
            if (itemIsLastVisible)
            {
                // oldest calls are in the bottom - load more oldest calls
                var paginationInitialDate = callModel.CreatedDate;
                await LoadData(paginationInitialDate, _minDay, _maxDay, _userType);
            }
        }
    }
}
