using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class ResetPasswordRequestModel : BaseModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("one_time_password")]
        public string OneTimePassword { get; set; }

        [JsonProperty("new_password")]
        public string NewPassword { get; set; }

        [JsonProperty("new_password_confirmation")]
        public string NewPasswordConfirmation { get; set; }
    }
}
