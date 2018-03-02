using System;
using System.Threading.Tasks;
using Interpretap.Models;
using static Interpretap.Common.ConfigApp;
using Interpretap.Models.RespondModels;

namespace Interpretap.Services
{
    public class MiscServices : BaseService
    {
        //public async Task<BaseRespond> FetchDeviceInfo(RegisterModel registeModel)
        //{
        //BaseRespond  = new BaseRespond();

        //try
        //{
        //    insertUserRespond = await Post<BaseRespond, RegisterModel>(InsertUserAPI, registeModel);
        //}
        //catch (Exception e)
        //{
        //    System.Diagnostics.Debug.WriteLine(e.Message);
        //}

        //return insertUserRespond;
        //}        

        public async Task<LanguagesResponce> FetchAllLanguages(BaseModel request)
        {
            var responce = new LanguagesResponce();

            try
            {
                responce = await Post<LanguagesResponce, BaseModel>(FetchAllLanguagesAPI, request);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }
    }
}
