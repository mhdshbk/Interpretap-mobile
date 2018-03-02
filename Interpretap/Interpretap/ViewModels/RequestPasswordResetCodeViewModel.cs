using Interpretap.Core;
using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class RequestPasswordResetCodeViewModel
    {
        RequestPasswordResetCodeModel _model = new RequestPasswordResetCodeModel();

        public string Username { get; set; }
        public ICommand SendForgotPasswordCommand { get; set; }
        public bool CanExecuteSendForgotPasswordCommand => !string.IsNullOrEmpty(Username) && !IsProcessing;
        public bool IsProcessing { get; set; }

        public RequestPasswordResetCodeViewModel()
        {
            SendForgotPasswordCommand = new Command(async () => await SendForgotPasswordCommandExecute());
        }

        private async Task SendForgotPasswordCommandExecute()
        {
            IsProcessing = true;
            await _model.SendForgotPassword(Username);
            IsProcessing = false;

            if (_model.Success)
            {
                await App.Current.MainPage.DisplayAlert("Success", _model.ResponceMessage, "OK");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", _model.ResponceMessage, "OK");
            }
        }
    }
}
