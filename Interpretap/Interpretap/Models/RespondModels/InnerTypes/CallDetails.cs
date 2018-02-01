using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels.InnerTypes
{
    public class CallDetails
    {
        [JsonProperty("call_info_id")]
        public string CallInfoId { get; set; }

        [JsonProperty("created_date")]
        public System.DateTime CreatedDate { get; set; }

        [JsonProperty("start_call_date")]
        public string StartCallDate { get; set; }

        [JsonProperty("call_reference_id")]
        public string CallReferenceId { get; set; }
    }
}
