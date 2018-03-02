using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class InterpreterInfoRequestModel : BaseModel
    {
        [JsonProperty("requested_interpreter_id")]
        public string InterpreterId { get; set; }
    }
}
