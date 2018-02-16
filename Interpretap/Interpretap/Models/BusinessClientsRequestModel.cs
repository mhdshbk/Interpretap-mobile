using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class BusinessClientsRequestModel : BaseModel
    {
        [JsonProperty("business_id")]
        public string BusinessId { get; set; }

        [JsonProperty("from_client_id")]
        public string FromClientId { get; set; }
    }
}
