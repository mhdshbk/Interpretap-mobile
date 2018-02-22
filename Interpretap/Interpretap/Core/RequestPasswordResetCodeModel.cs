using Interpretap.Models;
using Interpretap.Services;
using System.Threading.Tasks;

namespace Interpretap.Core
{
    public class RequestPasswordResetCodeModel
    {
        UserService service = new UserService();

        public bool Success { get; set; }
        public string ResponceMessage { get; set; }

        public async Task SendForgotPassword(string username)
        {
            var request = new ForgotPasswordRequestModel()
            {
                Username = username
            };
            var responce = await service.RequestPasswordResetCodePassword(request);
            Success = responce.Status == true;
            ResponceMessage = responce.Message;
        }
    }
}
