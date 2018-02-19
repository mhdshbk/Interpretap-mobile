using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class RateUserRequestModel : BaseModel
    {
        [JsonProperty("ratee_user_id")]
        public string RateeUserId { get; set; }

        [JsonProperty("call_id")]
        public string CallId { get; set; }

        [JsonProperty("rating_id")]
        public string RatingId { get; set; }
    }
}
