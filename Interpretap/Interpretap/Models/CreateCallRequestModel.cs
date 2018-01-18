using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.Models
{
    public class CreateCallRequestModel : BaseModel
    {
        [JsonProperty("call_ref_id")]
        public string CallRefId { get; set; }

        [JsonProperty("requested_language_id")]
        public string RequestedLanguageId { get; set; }

        [JsonProperty("client_language_id")]
        public string ClientLanguageId { get; set; }

        [JsonProperty("associated_client_business_id")]
        public string ClientBusinessId { get; set; }
    }
}
