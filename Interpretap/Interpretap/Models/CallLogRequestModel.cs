using Newtonsoft.Json;

namespace Interpretap.Models
{
    class CallLogRequestModel : BaseModel
    {
        [JsonProperty("from_date")]
        public string FromDate { get; set; }
    }
}
