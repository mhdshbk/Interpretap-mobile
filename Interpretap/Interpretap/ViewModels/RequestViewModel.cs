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

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class RequestViewModel
    {
        bool _isLoadingLanguages;

        public ObservableCollection<LanguageModel> Languages { get; set; }
        public LanguageModel SelectedLanguage { get; set; }
        public string CallRef { get; set; }

        public bool IsBusy { get; set; }
        public bool RequestCallEnabled => SelectedLanguage != null && CallRef != null;

        public ICommand CreateCallRequestCommand { get; set; }

        public RequestViewModel()
        {
            Languages = new ObservableCollection<LanguageModel>();
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
                request.ClientLanguageId = "1"; // TODO: fetch correct value from proper source
                request.RequestedLanguageId = SelectedLanguage.Id;
                request.ClientBusinessId = LocalStorage.LoginResponseLS.UserInfo.ClientInfo.Businesses.Last().ClientBusinessId.ToString();
                var responce = await service.CreateCallRequest(request);

                var isSuccessfull = responce.Status == true;
                if (isSuccessfull)
                {
                    await App.Current.MainPage.DisplayAlert("Success", responce.Message, "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", responce.Message, "Ok");
                }
            }
            catch (System.Exception)
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
                    Languages.Add(language);
                }

            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                _isLoadingLanguages = false;
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            if (Languages.Count == 0)
            {
                LoadLanguagesAsync();
            }
        }
    }
}
