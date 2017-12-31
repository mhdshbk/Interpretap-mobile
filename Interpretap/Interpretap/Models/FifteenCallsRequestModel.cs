using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class FifteenCallsRequestModel : BaseModel
    {
        //[JsonProperty("agency_id")]
        //public string AgencyId { get; set; }

        //[JsonProperty("business_id")]
        //public string BusinessId { get; set; }

        [JsonProperty("min_day")]
        public string MinDay { get; set; }

        [JsonProperty("from_date")]
        public string FromDate { get; set; }

        [JsonProperty("max_day")]
        public string MaxDay { get; set; }
    }
}
