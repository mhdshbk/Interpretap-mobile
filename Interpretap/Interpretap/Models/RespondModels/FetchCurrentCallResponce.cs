using Interpretap.Models.RespondModels.InnerTypes;
using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class FetchCurrentCallResponce : BaseRespond
    {
        [JsonProperty("call_id")]
        public string CallId { get; set; }

        [JsonProperty("call_info")]
        public CallInfo CallInfo { get; set; }
    }

    public partial class CallInfo
    {
        [JsonProperty("call_info")]
        public CallDetails CallDetails { get; set; }

        [JsonProperty("client_business_info")]
        public ClientBusinessInfo ClientBusinessInfo { get; set; }
    }


}
