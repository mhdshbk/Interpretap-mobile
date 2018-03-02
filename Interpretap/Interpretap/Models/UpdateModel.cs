using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.Models
{
    public class UpdateModel : BaseModel 
    {
        [JsonProperty("user_first_name")]
        public string FirstName { get; set; }

        [JsonProperty("user_last_name")]
        public string LastName { get; set; }

        [JsonProperty("user_password")]
        public string Password { get; set; }

        [JsonProperty("user_password_confirmation")]
        public string PasswordConfirmation { get; set; }

        [JsonProperty("user_phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("user_address")]
        public string Address { get; set; }

        [JsonProperty("user_email")]
        public string Email { get; set; }

        [JsonProperty("user_city")]
        public string City { get; set; }

        [JsonProperty("user_province")]
        public string Province { get; set; }

        [JsonProperty("user_zip_code")]
        public string ZipCode { get; set; }
    }
}
