using Newtonsoft.Json;
using System.Collections.Generic;

namespace Interpretap.Models.RespondModels
{
    public class FetchFifteenCallsRespnse
    {
        [JsonProperty("calls")]
        public List<FifteenCallModel> Calls { get; set; }
    }
}
