using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Interpretap.Models;
using Interpretap.Services;
using Xamarin.Forms;
using Interpretap.Common;
using System.Linq;
using Interpretap.Models.RespondModels;
using Interpretap.Interfaces;
using System.Windows.Input;

namespace Interpretap.ViewModels
{
    public class CallQueueViewModel : BaseViewModel
    {
        ICallQueueService _callQueueService;

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

        public ICommand RefreshCommand { get; set; }
        public bool IsRefreshing => false;

        public CallQueueViewModel()
        {
            _queueCalls = new ObservableCollection<OpenCallModel>();
            _callQueueService = new CallQueueService();
            _callQueueService.CallRequested += async (s, e) => await OnCallRequestedAsync(s, e);
            RefreshCommand = new Command(async () => await RefreshCommandExecute());
        }

        private async Task RefreshCommandExecute()
        {
            await ReloadData();
        }

        private async Task OnCallRequestedAsync(object sender, EventArgs e)
        {
            await ReloadData();
        }

        public async Task LoadData()
        {
            IsBusy = true;
            InterpreterService _interpreterService = new InterpreterService();
            var callResponse = await _interpreterService.FetchOpenCalls(new BaseModel());
            foreach (var call in callResponse.Calls)
            {
                call.AcceptCallRequested += async (s, e) => await AcceptCallRequestedAsync(s, e);
                QueueCalls.Add(call);
            }
            IsBusy = false;
        }

        public async Task ReloadData()
        {
            QueueCalls.Clear();
            await LoadData();
        }

        private async Task AcceptCallRequestedAsync(object sender, EventArgs e)
        {
            var businessIdInt = await Dialogs.SelectInterpreterBusinessActionSheetAsync("Agency", "Cancel");
            if (businessIdInt != 0)
            {
                IsBusy = true;
                var responce = await AssignInterpreterToCallAsync((OpenCallModel)sender, businessIdInt.ToString());
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
        }

        private async Task<AssignInterpreterResponce> AssignInterpreterToCallAsync(OpenCallModel call, string businessId)
        {
            var service = new InterpreterService();
            var request = new AssignInterpreterRequestModel();
            request.AssociatedInterpreterBusiness = businessId;
            request.CallId = call.CallInfoId.ToString();
            var responce = await service.AssignInterpreterToCall(request);
            return responce;
        }
    }
}
