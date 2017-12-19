using Interpretap.Models.RespondModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.Models.RespondModels
{
    public class LoginRespond : BaseRespond
    {
        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        [JsonProperty("user_info")]
        public UserModel UserInfo { get; set; }
    }
}
