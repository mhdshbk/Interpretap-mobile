using static Interpretap.Common.ConfigApp;
using Interpretap.Models;
using System;
using System.Threading.Tasks;
using Interpretap.Models.RespondModels;

namespace Interpretap.Services
{
    class UserService : BaseService
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
    }
}
