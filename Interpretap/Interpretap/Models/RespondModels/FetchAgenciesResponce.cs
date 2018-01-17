using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class FetchAgenciesResponce : BaseRespond
    {
        [JsonProperty("agencies")]
        public AgencyModel[] Agencies { get; set; }
    }
}
