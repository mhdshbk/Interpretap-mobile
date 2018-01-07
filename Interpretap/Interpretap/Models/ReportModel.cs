using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class ReportModel
    {
        [JsonProperty("total_fee_amount")]
        public double TotalFee { get; set; }

        [JsonProperty("total_pause_amount")]
        public int TotalPause { get; set; }

        [JsonProperty("total_call_amount")]
        public int TotalCall { get; set; }
    }

    public class FeeInfo
    {
        [JsonProperty("fee_amount_per_minute")]
        public double FeePerMinute { get; set; }
    }
    
    public class BillInfo
    {
        [JsonProperty("bill_amount_per_minute")]
        public double FeePerMinute { get; set; }
    }
}
