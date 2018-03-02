using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class AddInterpreterToAgencyRequestModel : BaseModel
    {
        [JsonProperty("agency_id")]
        public string AgencyId { get; set; }

        [JsonProperty("new_interpreter_id")]
        public string InterpreterId { get; set; }

        [JsonProperty("is_manager")]
        public string IsManager { get; set; }
    }
}
