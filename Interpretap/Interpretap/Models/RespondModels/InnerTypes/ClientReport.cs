using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels.InnerTypes
{
    public class CallReport
    {
        [JsonProperty("start_date")]
        public System.DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public System.DateTime EndDate { get; set; }

        [JsonProperty("report_info")]
        public ReportInfo ReportInfo { get; set; }
    }
}
