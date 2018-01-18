using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class LanguageModel
    {
        [JsonProperty("language_id")]
        public string Id { get; set; }

        [JsonProperty("language_name")]
        public string Name { get; set; }
    }
}
