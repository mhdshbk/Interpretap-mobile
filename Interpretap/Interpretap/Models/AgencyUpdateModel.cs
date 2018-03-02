using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class AgencyUpdateModel : BaseModel
    {
        [JsonProperty("agency_name")]
        public string Name { get; set; }

        [JsonProperty("agency_phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("agency_address")]
        public string Address { get; set; }

        [JsonProperty("agency_email")]
        public string Email { get; set; }

        [JsonProperty("agency_city")]
        public string City { get; set; }

        [JsonProperty("agency_province")]
        public string Province { get; set; }

        [JsonProperty("agency_zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("agency_id")]
        public string Id { get; set; }
    }
}
