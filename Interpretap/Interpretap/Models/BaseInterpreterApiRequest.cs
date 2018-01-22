using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class BaseInterpreterApiRequest : BaseModel
    {
        [JsonProperty("call_id")]
        public string CallId { get; set; }
    }
}
