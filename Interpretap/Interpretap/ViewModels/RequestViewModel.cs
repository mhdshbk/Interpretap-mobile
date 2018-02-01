using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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

        public  ActiveCallViewModel ActiveCallViewModel { get; set; }
        public bool ActiveCallExists => App.ActiveCall.ActiveCallExist;
        public bool RequestAreaVisible => !App.ActiveCall.ActiveCallExist;

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
            ActiveCallViewModel = new ActiveCallViewModel();

            ActiveCallViewModel.CallCanceled += ActiveCallViewModel_CallCanceled;
            App.ActiveCall.PropertyChanged += ActiveCall_PropertyChanged;
        }

        private void ActiveCallViewModel_CallCanceled(object sender, EventArgs e)
        {
            IsBusy = true;
        }

        private void ActiveCall_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(App.ActiveCall.ActiveCallExist))
            {
                NotifyPropertiesChanged();
                IsBusy = false;
            }
        }

        private async Task ExecuteCreateCallRequestAsync()
        {
            try
            {
                IsBusy = true;

                var request = new CreateCallRequestModel
                {
                    CallRefId = CallRef,
                    ClientLanguageId = SelectedClientLanguage.Id,
                    RequestedLanguageId = SelectedRequestLanguage.Id,
                    ClientBusinessId = SelectedBusiness.ClientBusinessId.ToString()
                };

                var responce = await App.ActiveCall.RequestNewCall(request);

                var isSuccessfull = responce.Status == true;
                if (isSuccessfull)
                {
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

        private void NotifyPropertiesChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RequestCallEnabled)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RequestAreaVisible)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveCallExists)));
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
            NotifyPropertiesChanged();
            ActiveCallViewModel.OnAppearing();
        }
    }
}
