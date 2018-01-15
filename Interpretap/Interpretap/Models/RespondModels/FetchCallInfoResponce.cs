using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class FetchCallInfoResponce
    {
        [JsonProperty("call_info")]
        public CallInfoModel CallInfo { get; set; }
    }
}
