using Newtonsoft.Json;
using System.Collections.Generic;

namespace Interpretap.Models.RespondModels
{
    public class FetchFifteenCallsRespnse
    {
        [JsonProperty("calls")]
        public List<FifteenCallModel> Calls { get; set; }
    }

    public class FetchFifteenCallsABResponse
    {
        [JsonProperty("calls")]
        public FetchFifteenCallsABResponseContent Call { get; set; }
    }

    public class FetchFifteenCallsABResponseContent
    {
        [JsonProperty("call_info")]
        public List<FifteenCallModel> Calls { get; set; }
    }
}
