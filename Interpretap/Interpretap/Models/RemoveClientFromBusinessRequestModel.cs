using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class RemoveClientFromBusinessRequestModel : BaseModel
    {
        [JsonProperty("business_id")]
        public string BusinessId { get; set; }

        [JsonProperty("removed_client_id")]
        public string ClientId { get; set; }
    }
}
