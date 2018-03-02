using System;
using System.Collections.Generic;
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
            catch(KeyNotFoundException)
            {
                this.SessionKey = "";
            }
            catch(NullReferenceException)
            {
                this.SessionKey = "";
            }
        }
    }
}
