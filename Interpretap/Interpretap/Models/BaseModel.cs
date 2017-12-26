using System;
using Interpretap.Common;
using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class BaseModel
    {
        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        public BaseModel()
        {
            this.SessionKey = LocalStorage.LoginResponseLS.SessionKey;
        }
    }
}
