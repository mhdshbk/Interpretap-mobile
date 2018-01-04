using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class FifteenCallsRequestModel : BaseModel
    {
        [JsonProperty("agency_id")]
        public int AgencyId { get; set; }

        [JsonProperty("client_business_id")]
        public int ClientBusinessId { get; set; }

        [JsonProperty("min_day")]
        public string MinDay { get; set; }

        [JsonProperty("from_date")]
        public string FromDate { get; set; }

        [JsonProperty("max_day")]
        public string MaxDay { get; set; }
    }
}
