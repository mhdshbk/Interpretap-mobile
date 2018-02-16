using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels.InnerTypes
{
    public class BusinessClient
    {
        [JsonProperty("client_first_name")]
        public string ClientFirstName { get; set; }

        [JsonProperty("client_last_name")]
        public string ClientLastName { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("client_email")]
        public string ClientEmail { get; set; }

        [JsonProperty("client_phone_number")]
        public string ClientPhoneNumber { get; set; }

        [JsonProperty("client_address")]
        public string ClientAddress { get; set; }

        [JsonProperty("client_city")]
        public string ClientCity { get; set; }

        [JsonProperty("client_province")]
        public string ClientProvince { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("is_manager")]
        public string IsManager { get; set; }
    }
}
