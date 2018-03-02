using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class AgencyModel
    {
        [JsonProperty("interpreter_business_id")]
        public string InterpreterBusinessId { get; set; }

        [JsonProperty("is_manager")]
        public string IsManager { get; set; }

        [JsonProperty("business_info")]
        public BusinessInfo BusinessInfo { get; set; }
    }
}
