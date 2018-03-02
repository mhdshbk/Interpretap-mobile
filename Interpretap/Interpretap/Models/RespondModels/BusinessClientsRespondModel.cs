using Interpretap.Models.RespondModels.InnerTypes;
using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class BusinessClientsRespondModel : BaseModel
    {
        [JsonProperty("business_clients")]
        public BusinessClient[] BusinessClients { get; set; }
    }
}
