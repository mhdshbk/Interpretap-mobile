using Interpretap.Core;
using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ResetPasswordViewModel
    {
        ResetPasswordModel _model = new ResetPasswordModel();

        public string Username { get; set; }
        public string OneTimePassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirmation { get; set; }
        public bool IsProcessing { get; set; }

        public ICommand SendResetPasswordRequestCommand { get; set; }
        public bool CanExecuteSendResetPasswordRequestCommand =>
            !string.IsNullOrEmpty(Username)
            && !string.IsNullOrEmpty(OneTimePassword)
            && !string.IsNullOrEmpty(NewPassword)
            && !string.IsNullOrEmpty(NewPasswordConfirmation);

        public ResetPasswordViewModel()
        {
            SendResetPasswordRequestCommand = new Command(async () => await SendResetPasswordRequestCommandExecute());
        }

        private async Task SendResetPasswordRequestCommandExecute()
        {
            if (NewPassword != NewPasswordConfirmation)
            {
                await App.Current.MainPage.DisplayAlert("Warning", "New Password and Confirm Password values must be same", "OK");
                return;
            }

            IsProcessing = true;
            await _model.SendResetPasswordAsync(Username, OneTimePassword, NewPassword, NewPasswordConfirmation);
            IsProcessing = false;

            if (_model.ResponceSuccess)
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
