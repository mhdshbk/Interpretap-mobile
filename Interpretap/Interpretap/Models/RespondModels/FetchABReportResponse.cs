using Newtonsoft.Json;
using System.Collections.Generic;

namespace Interpretap.Models.RespondModels
{
    public class FetchABReportResponse
    {
        [JsonProperty("agency_report")]
        public FetchABReportResponseContent AgencyReport { get; set; }

        [JsonProperty("client_business_report")]
        public FetchABReportResponseContent BusinessReport { get; set; }
    }

    public class FetchABReportResponseContent
    {
        [JsonProperty("report_info")]
        public ReportModel Report { get; set; }

        [JsonProperty("associated_fee_info")] 
        public List<FeeInfo> FeeInfos { get; set; }

        [JsonProperty("associated_bill_info")]
        public List<BillInfo> BillInfo { get; set; }
    }
}
