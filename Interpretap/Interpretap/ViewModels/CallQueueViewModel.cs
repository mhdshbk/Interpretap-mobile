using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Interpretap.Models;
using Interpretap.Services;
using Xamarin.Forms;
using Interpretap.Common;
using System.Linq;
using Interpretap.Models.RespondModels;

namespace Interpretap.ViewModels
{
    public class CallQueueViewModel : BaseViewModel
    {
        private ObservableCollection<OpenCallModel> _queueCalls;
        public ObservableCollection<OpenCallModel> QueueCalls
        {
            get { return _queueCalls; }
            set { _queueCalls = value; INotifyPropertyChanged(); }
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

        public CallQueueViewModel()
        {
            _queueCalls = new ObservableCollection<OpenCallModel>();
        }

        public async Task LoadData()
        {
            InterpreterService _interpreterService = new InterpreterService();
            var callResponse = await _interpreterService.FetchOpenCalls(new BaseModel());
            foreach (var call in callResponse.Calls)
            {
                call.AcceptCallRequested += async (s,e) => await AcceptCallRequestedAsync(s,e);
                QueueCalls.Add(call);
            }
        }

        private async Task AcceptCallRequestedAsync(object sender, EventArgs e)
        {
            IsBusy = true;
            var responce = await AssignInterpreterToCallAsync((OpenCallModel)sender);
            var acceptSuccess = responce.Status;
            if (acceptSuccess)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.InterpreterViews.TimerPage(responce.CallId));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", responce.Message, "Ok");
            }
            IsBusy = false;
        }

        private async Task<AssignInterpreterResponce> AssignInterpreterToCallAsync(OpenCallModel call)
        {
            IsBusy = true;
            var service = new InterpreterService();
            var request = new AssignInterpreterRequestModel();
            request.AssociatedInterpreterBusiness = LocalStorage.LoginResponseLS.UserInfo.InterpreterInfo.Agencies.Last().InterpreterBusinessId.ToString();
            request.CallId = call.CallInfoId.ToString();
            var responce = await service.AssignInterpreterToCall(request);
            return responce;
        }
    }
}
