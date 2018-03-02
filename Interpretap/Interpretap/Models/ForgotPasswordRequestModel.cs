using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class ForgotPasswordRequestModel : BaseModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
