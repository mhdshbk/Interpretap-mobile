using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class FetchOpenCallResponce : BaseRespond
    {
        [JsonProperty("call_id")]
        public string CallId { get; set; }
    }
}
