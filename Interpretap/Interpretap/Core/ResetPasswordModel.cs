using Interpretap.Models;
using Interpretap.Services;
using System.Threading.Tasks;

namespace Interpretap.Core
{
    public class ResetPasswordModel
    {
        UserService _service = new UserService();

        public bool ResponceSuccess { get; set; }
        public string ResponceMessage { get; set; }

        public async Task SendResetPasswordAsync(string userName, string oneTimePassword, string newPassword, string newPasswordConfirmation)
        {
            var request = new ResetPasswordRequestModel()
            {
                Username = userName,
                OneTimePassword = oneTimePassword,
                NewPassword = newPassword,
                NewPasswordConfirmation = newPasswordConfirmation,
            };
            var responce = await _service.ResetPassword(request);
            ResponceSuccess = responce.Status == true;
            ResponceMessage = responce.Message;
        }
    }
}
