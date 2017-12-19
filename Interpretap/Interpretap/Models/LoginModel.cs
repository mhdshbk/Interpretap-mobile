using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.Models
{
    public class LoginModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("session_type")]
        public string SessionType { get; set; }

        [JsonProperty("override_session")]
        public int OverrideSession { get; set; }

        public LoginModel(string username, string password, string sessionType, int overrideSession = 1)
        {
            this.Username = username;
            this.Password = password;
            this.SessionType = sessionType;
            this.OverrideSession = overrideSession;
        }
    }
}
