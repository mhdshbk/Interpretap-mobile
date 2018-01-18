using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class LanguagesResponce : BaseRespond
    {
        [JsonProperty("language_info")]
        public LanguageModel[] Languages { get; set; }
    }
}
