using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class AddClientToBusinessRequestModel : BaseModel
    {
        [JsonProperty("business_id")]
        public string BusinessId { get; set; }

        [JsonProperty("new_client_id")]
        public string ClientId { get; set; }

        [JsonProperty("is_manager")]
        public string IsManager { get; set; }
    }
}
