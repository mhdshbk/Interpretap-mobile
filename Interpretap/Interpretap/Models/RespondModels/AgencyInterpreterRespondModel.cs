using Interpretap.Models.RespondModels.InnerTypes;
using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class AgencyInterpreterRespondModel : BaseRespond
    {
        [JsonProperty("agency_interpreters")]
        public AgencyInterpreter[] AgencyInterpreters { get; set; }
    }
}
