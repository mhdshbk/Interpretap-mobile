using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class CancelCallRequestModel : BaseModel
    {
        [JsonProperty("call_id")]
        public string CallId { get; set; }
    }
}
