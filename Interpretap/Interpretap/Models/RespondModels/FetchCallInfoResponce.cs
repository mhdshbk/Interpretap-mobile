using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class FetchCallInfoResponce : BaseRespond
    {
        [JsonProperty("call_info")]
        public CallInfoModel CallInfo { get; set; }
    }
}
