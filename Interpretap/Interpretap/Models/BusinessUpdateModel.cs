using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class BusinessUpdateModel : BaseModel
    {
        [JsonProperty("business_name")]
        public string Name { get; set; }

        [JsonProperty("business_phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("business_address")]
        public string Address { get; set; }

        [JsonProperty("business_email")]
        public string Email { get; set; }

        [JsonProperty("business_city")]
        public string City { get; set; }

        [JsonProperty("business_province")]
        public string Province { get; set; }

        [JsonProperty("business_zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("client_business_id")]
        public string Id { get; set; }
    }
}
