using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class FetchUserRespond : BaseRespond
    {
        [JsonProperty("user_info")]
        public UserModel UserInfo { get; set; }
    }
}
