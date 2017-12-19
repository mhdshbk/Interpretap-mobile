using Interpretap.Models.RespondModels;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;

namespace Interpretap.Common
{
    public static class LocalStorage
    {
        private const string login_reponse_key = "interapt_login_respond_key";

        public static LoginRespond LoginResponseLS
        {
            get => JsonConvert.DeserializeObject<LoginRespond>(Application.Current.Properties[login_reponse_key] as String);

            set => Application.Current.Properties[login_reponse_key] = JsonConvert.SerializeObject(value);
        }
    }
}
