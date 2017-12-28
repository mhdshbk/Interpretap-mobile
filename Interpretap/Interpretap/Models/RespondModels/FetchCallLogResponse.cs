using Newtonsoft.Json;
using System.Collections.Generic;

namespace Interpretap.Models.RespondModels
{
    class FetchCallLogResponse : BaseRespond
    {
        [JsonProperty("monthly_call_info")]
        public List<MonthlyCallReportModel> CallLogs { get; set; }
    }
}
