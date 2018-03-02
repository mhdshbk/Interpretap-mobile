using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class RemoveInterpreterFromAgencyRequestModel : BaseModel
    {
        [JsonProperty("agency_id")]
        public string AgencyId { get; set; }

        [JsonProperty("removed_interpreter_id")]
        public string InterpreterId { get; set; }
    }
}
