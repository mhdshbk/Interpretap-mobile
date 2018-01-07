using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class CallReportRequestModel : BaseModel
    {
        [JsonProperty("min_day")]
        public string MinDay { get; set; }

        [JsonProperty("max_day")]
        public string MaxDay{ get; set; }

        [JsonProperty("agency_id")]
        public int AgencyId { get; set; }

        [JsonProperty("client_business_id")]
        public int ClientBusinessId { get; set; }
    }
}