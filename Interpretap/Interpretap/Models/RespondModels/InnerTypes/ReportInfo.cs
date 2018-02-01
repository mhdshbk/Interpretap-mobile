using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels.InnerTypes
{
    public class ReportInfo
    {
        [JsonProperty("total_pause_amount")]
        public long TotalPauseAmountSeconds { get; set; }

        [JsonProperty("total_call_amount")]
        public long TotalCallAmountSeconds { get; set; }
    }
}
