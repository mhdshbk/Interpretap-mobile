using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class AgencyInterpretersRequestModel : BaseModel
    {
        [JsonProperty("agency_id")]
        public string AgencyId { get; set; }

        [JsonProperty("from_interpreter_id")]
        public string FromInterpreterId { get; set; }
    }
}
