using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class BaseRespond
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
