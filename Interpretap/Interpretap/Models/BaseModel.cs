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
            try
            {
                this.SessionKey = LocalStorage.LoginResponseLS.SessionKey;
            }
            catch(NullReferenceException)
            {
                this.SessionKey = "";
            }
        }
    }
}
