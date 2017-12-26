using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class FetchOpenCallsResponse : BaseRespond
    {
        [JsonProperty("calls")]
        public OpenCallModel Calls { get; set; }
    }
}
