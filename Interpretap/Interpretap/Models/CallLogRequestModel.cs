using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class CallLogRequestModel : BaseModel
    {
        [JsonProperty("from_date")]
        public string FromDate { get; set; }

        [JsonProperty("agency_id")]
        public int AgencyId { get; set; }

        [JsonProperty("client_business_id")]
        public int ClientBusinessId { get; set; }
    }
}
