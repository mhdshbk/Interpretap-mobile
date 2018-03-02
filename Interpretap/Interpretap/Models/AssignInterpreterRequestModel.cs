using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class AssignInterpreterRequestModel : BaseModel
    {
        [JsonProperty("call_id")]
        public string CallId { get; set; }

        [JsonProperty("associated_interpreter_business")]
        public string AssociatedInterpreterBusiness { get; set; }
    }
}
