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
        private const string client_onesignal_id_key = "client_onesignal_id_key";
        private const string interpreter_onesignal_id_key = "interpreter_onesignal_id_key";

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

        public static string ClientOneSignalId
        {
            get
            {
                object id = "";
                if (Application.Current.Properties.TryGetValue(client_onesignal_id_key, out id))
                {
                    return id.ToString();
                }
                else
                {
                    return null;
                }
            }

            set
            {
                Application.Current.Properties[client_onesignal_id_key] = value;
                Application.Current.SavePropertiesAsync().GetAwaiter();
            }
        }

        public static string InterpreterOneSignalId
        {
            get
            {
                object id = "";
                if (Application.Current.Properties.TryGetValue(interpreter_onesignal_id_key, out id))
                {
                    return id.ToString();
                }
                else
                {
                    return null;
                }
            }

            set
            {
                Application.Current.Properties[interpreter_onesignal_id_key] = value;
                Application.Current.SavePropertiesAsync().GetAwaiter();
            }
        }
    }
}
