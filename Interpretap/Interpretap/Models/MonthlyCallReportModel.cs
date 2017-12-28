using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.Models
{
    class MonthlyCallReportModel
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
