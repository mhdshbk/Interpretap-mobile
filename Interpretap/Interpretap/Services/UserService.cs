using Interpretap.Models;
using Interpretap.Models.RespondModels;
using System;
using System.Threading.Tasks;
using static Interpretap.Common.ConfigApp;

namespace Interpretap.Services
{
    class UserService : BaseServiceNoNulls
    {
        public async Task<LoginRespond> Login(LoginModel loginModel)
        {
            LoginRespond loginRespond = new LoginRespond();

            try
            {
                loginRespond = await Post<LoginRespond, LoginModel>(LoginUserAPI, loginModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return loginRespond;
        }

        public async Task<FetchUserRespond> FetchUserInfo(LoginModel loginModel)
        {
            FetchUserRespond fetchUserRespond = new FetchUserRespond();

            try
            {
                fetchUserRespond = await Post<FetchUserRespond, LoginModel>(FetchUserAPI, loginModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchUserRespond;
        }

        public async Task<BaseRespond> InsertUser(RegisterModel registeModel)
        {
            BaseRespond insertUserRespond = new BaseRespond();

            try
            {
                insertUserRespond = await Post<BaseRespond, RegisterModel>(InsertUserAPI, registeModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return insertUserRespond;
        }

        public async Task<BaseRespond> UpdateUser(UpdateModel registeModel)
        {
            BaseRespond updateUserRespond = new BaseRespond();

            try
            {
                updateUserRespond = await PostNoNulls<BaseRespond, UpdateModel>(UpdateUserAPI, registeModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return updateUserRespond;
        }

        public async Task<BaseRespond> Logout(BaseModel model)
        {
            var respond = new BaseRespond();

            try
            {
                respond = await Post<BaseRespond, BaseModel>(LogoutUserAPI, model);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return respond;
        }

        public async Task<FetchCurrentCallResponce> FetchCurrentCall(BaseModel requestModel)
        {
            var responce = new FetchCurrentCallResponce();

            try
            {
                responce = await Post<FetchCurrentCallResponce, BaseModel>(FetchCurrentCallUserAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> UpdateDeviceId(UpdateDeviceIdRequestModel requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, UpdateDeviceIdRequestModel>(UpdateDeviceIdUserAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> RateUser(RateUserRequestModel requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, RateUserRequestModel>(RateUserAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> ResetPassword(ResetPasswordRequestModel requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, ResetPasswordRequestModel>(ResetPasswordUserAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> RequestPasswordResetCodePassword(ForgotPasswordRequestModel requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, ForgotPasswordRequestModel>(ForgotPasswordUserAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }
    }
}
