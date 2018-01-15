using Interpretap.Models;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.ViewModels
{
    public class CallInfoViewModel : BaseViewModel
    {
        int _callInfoId;
        CallInfoModel _callInfoModel;

        public string InfoId => _callInfoModel.CallInfoId;
        public string ReferenceId => _callInfoModel.CallReferenceId;
        public string CreatedDate => _callInfoModel.CreatedDate;
        public string StartDate => _callInfoModel.CallStartDate;
        public string EndDate => _callInfoModel.CallEndDate;
        public string Duration => _callInfoModel.CallDuration;

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

        public CallInfoViewModel(FifteenCallModel call)
        {
            _callInfoModel = new CallInfoModel();
            LoadDataAsync(call.CallInfoId).GetAwaiter();
        }

        async Task LoadDataAsync(int callId)
        {
            IsBusy = true;
            var callRequestModel = new CallRequestModel();
            callRequestModel.CallInfoId = callId;
            var service = new CallService();
            var responce = await service.FetchCall(callRequestModel);
            _callInfoModel = responce.CallInfo;
            NotifyModelChanged();
            IsBusy = false;
        }

        void NotifyModelChanged()
        {
            INotifyPropertyChanged(nameof(InfoId));
            INotifyPropertyChanged(nameof(ReferenceId));
            INotifyPropertyChanged(nameof(CreatedDate));
            INotifyPropertyChanged(nameof(StartDate));
            INotifyPropertyChanged(nameof(EndDate));
            INotifyPropertyChanged(nameof(Duration));
        }
    }
}
