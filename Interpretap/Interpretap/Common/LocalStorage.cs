using Interpretap.Models.RespondModels;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;

namespace Interpretap.Common
{
    public static class LocalStorage
    {
        private const string login_reponse_key = "interapt_login_respond_key";
        private const string request_call_recents_key = "request_call_recents_key";

        public static LoginRespond LoginResponseLS
        {
            get => JsonConvert.DeserializeObject<LoginRespond>(Application.Current.Properties[login_reponse_key] as String);

            set => Application.Current.Properties[login_reponse_key] = JsonConvert.SerializeObject(value);
        }

        public static RequestCallRecents RequestCallRecents
        {
            get
            {
                object callRecentsString = "";
                if (Application.Current.Properties.TryGetValue(request_call_recents_key, out callRecentsString))
                {
                    //Application.Current.Properties[request_call_recents_key] as String
                    return JsonConvert.DeserializeObject<RequestCallRecents>(callRecentsString.ToString());
                }
                else
                {
                    return null;
                }
            }
 
            set
            {
                Application.Current.Properties[request_call_recents_key] = JsonConvert.SerializeObject(value);
                Application.Current.SavePropertiesAsync().GetAwaiter();
            }
        }
    }
}
