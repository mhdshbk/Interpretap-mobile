using Interpretap.Models;
using Interpretap.Services;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;
using Interpretap.Common;
using System.Linq;
using System.Collections.Generic;

namespace Interpretap.ViewModels
{
    public class RequestViewModel : INotifyPropertyChanged
    {
        bool _isLoadingLanguages;
        bool _isRecentsApplied;

        public event PropertyChangedEventHandler PropertyChanged;

        public LanguageModel[] ClientLanguages { get; set; }
        public LanguageModel SelectedClientLanguage { get; set; }
        public ObservableCollection<LanguageModel> RequestLanguages { get; set; }
        public LanguageModel SelectedRequestLanguage { get; set; }
        public List<AssosiateBusiness> Businesses { get; set; }
        public AssosiateBusiness SelectedBusiness { get; set; }
        public string CallRef { get; set; }

        public bool IsBusy { get; set; }
        public bool RequestCallEnabled
        {
            get
            {
                return
                    SelectedRequestLanguage != null
                    && !string.IsNullOrEmpty(CallRef)
                    && SelectedClientLanguage != null
                    && SelectedBusiness != null;
            }
        }
        public bool CanSelectBusiness => Businesses.Count > 1;

        public ICommand CreateCallRequestCommand { get; set; }

        public RequestViewModel()
        {
            ClientLanguages = LocalStorage.LoginResponseLS.UserInfo.LanguageInfo;
            RequestLanguages = new ObservableCollection<LanguageModel>();
            Businesses = LocalStorage.LoginResponseLS.UserInfo.ClientInfo.Businesses;
            if (Businesses.Count == 1)
            {
                SelectedBusiness = Businesses.Last();
            }
            CreateCallRequestCommand = new Command(async () => await ExecuteCreateCallRequestAsync());
        }

        private async Task ExecuteCreateCallRequestAsync()
        {
            try
            {
                IsBusy = true;

                var service = new ClientService();
                var request = new CreateCallRequestModel();
                request.CallRefId = CallRef;
                request.ClientLanguageId = SelectedClientLanguage.Id;
                request.RequestedLanguageId = SelectedRequestLanguage.Id;
                request.ClientBusinessId = SelectedBusiness.ClientBusinessId.ToString();
                var responce = await service.CreateCallRequest(request);

                var isSuccessfull = responce.Status == true;
                if (isSuccessfull)
                {
                    App.FetchActiveCallRequestAsync();
                    await App.Current.MainPage.DisplayAlert("Success", responce.Message, "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", responce.Message, "Ok");
                }

                StoreRecentValues();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task LoadLanguagesAsync()
        {
            if (_isLoadingLanguages) return;
            try
            {
                IsBusy = true;
                _isLoadingLanguages = true;

                var service = new MiscServices();
                var request = new BaseModel();
                var responce = await service.FetchAllLanguages(request);

                foreach (var language in responce.Languages)
                {
                    RequestLanguages.Add(language);
                }

                if (!_isRecentsApplied)
                {
                    ApplyRecentValues();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _isLoadingLanguages = false;
                IsBusy = false;
            }
        }

        void StoreRecentValues()
        {
            LocalStorage.RequestCallRecents = new RequestCallRecents()
            {
                CallRef = this.CallRef,
                SelectedClientLanguage = this.SelectedClientLanguage.Id,
                SelectedRequestLanguage = this.SelectedRequestLanguage.Id,
                SelectedBusiness = this.SelectedBusiness.ClientBusinessId.ToString()
            };
        }

        void ApplyRecentValues()
        {
            var recents = LocalStorage.RequestCallRecents;
            var recentsExisted = recents != null;
            if (recentsExisted)
            {
                CallRef = recents.CallRef;
                SelectedClientLanguage = ClientLanguages.FirstOrDefault(l => l.Id == recents.SelectedClientLanguage);
                SelectedRequestLanguage = RequestLanguages.FirstOrDefault(l => l.Id == recents.SelectedRequestLanguage);
                if (SelectedBusiness == null)
                {
                    SelectedBusiness = Businesses.FirstOrDefault(l => l.ClientBusinessId.ToString() == recents.SelectedBusiness);
                }
            }
            _isRecentsApplied = true;
        }

        public async Task OnAppearingAsync()
        {
            if (RequestLanguages.Count == 0)
            {
                await LoadLanguagesAsync();
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RequestCallEnabled)));
        }
    }
}
