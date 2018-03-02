using Interpretap.Models.RespondModels;
using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class AssignInterpreterResponce : BaseRespond
    {
        [JsonProperty("call_id")]
        public string CallId { get; set; }
    }
}
