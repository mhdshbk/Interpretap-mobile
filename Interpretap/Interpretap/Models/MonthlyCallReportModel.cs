using Newtonsoft.Json;
using System;

namespace Interpretap.Models
{
    public class MonthlyCallReportModel
    {
        [JsonProperty("start_of_month")]
        public String StartOfMonth { get; set; }

        [JsonProperty("end_of_month")]
        public String EndOfMonth { get; set; }

        [JsonProperty("total_call")]
        public int TotalCalls { get; set; }

        public String DateFromTo { get { return $"{StartOfMonth} to {EndOfMonth}"; } }
    }
}
