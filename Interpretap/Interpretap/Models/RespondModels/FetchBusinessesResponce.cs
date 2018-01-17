using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class FetchBusinessesResponce : BaseRespond
    {
        [JsonProperty("businesses")]
        public BusinessModel[] Businesses { get; set; }
    }
}
