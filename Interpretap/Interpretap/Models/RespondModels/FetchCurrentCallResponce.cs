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
        [JsonProperty("client_business_info")]
        public ClientBusinessInfo ClientBusinessInfo { get; set; }

        [JsonProperty("session_type")]
        public string SessionType { get; set; }

        [JsonProperty("call_status_info")]
        public CallStatusInfo CallStatusInfo { get; set; }

        [JsonProperty("call_info")]
        public CallDetails CallDetails { get; set; }

        [JsonProperty("interpreter_info")]
        public InterpreterInfo InterpreterInfo { get; set; }

        [JsonProperty("agency_info")]
        public AgencyInfo AgencyInfo { get; set; }

        [JsonProperty("pause_info")]
        public bool PauseInfo { get; set; }
    }

    public partial class CallStatusInfo
    {
        [JsonProperty("call_status")]
        public string CallStatus { get; set; }

        [JsonProperty("call_status_id")]
        public string CallStatusId { get; set; }
    }

    public partial class AgencyInfo
    {
        [JsonProperty("interpreter_business_id")]
        public string InterpreterBusinessId { get; set; }

        [JsonProperty("interpreter_origin_business_id")]
        public string InterpreterOriginBusinessId { get; set; }

        [JsonProperty("interpreter_business_name")]
        public string InterpreterBusinessName { get; set; }
    }
}
