using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class BusinessModel
    {
        [JsonProperty("client_business_id")]
        public string ClientBusinessId { get; set; }

        [JsonProperty("is_manager")]
        public string IsManager { get; set; }

        [JsonProperty("business_info")]
        public BusinessInfo BusinessInfo { get; set; }
    }
}
