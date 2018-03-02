using Newtonsoft.Json;
using System.Collections.Generic;

namespace Interpretap.Models
{
    public class UserModel
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("user_name")]
        public string Username { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("language_info")]
        public LanguageModel[] LanguageInfo { get; set; }

        [JsonProperty("is_manager")]
        public bool IsManager { get; set; }

        [JsonProperty("client_info")]
        public ClientInfo ClientInfo { get; set; }

        [JsonProperty("interpreter_info")]
        public InterpreterInfo InterpreterInfo { get; set; }
    }

    public class ClientInfo
    {
        [JsonProperty("client_id")]
        public int ClientId { get; set; }

        [JsonProperty("call_client_first_name")]
        public string ClientFirstName { get; set; }

        [JsonProperty("call_client_last_name")]
        public string ClientLastName { get; set; }

        [JsonProperty("associated_businesses")]
        public List<AssosiateBusiness> Businesses { get; set; }
    }

    public class InterpreterInfo
    {
        [JsonProperty("interpreter_id")]
        public int InterpreterId { get; set; }

        [JsonProperty("interpreter_user_id")]
        public string InterpreterUserId { get; set; }

        [JsonProperty("call_interpreter_first_name")]
        public string InterpreterFirstName { get; set; }

        [JsonProperty("call_interpreter_last_name")]
        public string InterpreterLastName { get; set; }

        [JsonProperty("associated_agencies")]
        public List<AssosiateAgencies> Agencies { get; set; }
    }

    public class AssosiateBusiness
    {
        [JsonProperty("client_business_id")]
        public int ClientBusinessId { get; set; }

        [JsonProperty("is_manager")]
        public int IsManager { get; set; }

        [JsonProperty("business_info")]
        public BusinessInfo BusinessInfo { get; set; }
    }

    public class AssosiateAgencies
    {
        [JsonProperty("interpreter_business_id")]
        public int InterpreterBusinessId { get; set; }

        [JsonProperty("is_manager")]
        public int IsManager { get; set; }

        [JsonProperty("business_info")]
        public BusinessInfo BusinessInfo { get; set; }
    }
    
    public class BusinessInfo
    {
        [JsonProperty("core_business_id")]
        public int CoreBusinessId { get; set; }

        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("business_email")]
        public string BusinessEmail { get; set; }

        [JsonProperty("business_phone_number")]
        public string BusinessPhoneNumber { get; set; }

        [JsonProperty("business_address")]
        public string BusinessAddress { get; set; }

        [JsonProperty("business_city")]
        public string BusinessCity { get; set; }

        [JsonProperty("business_province")]
        public string BusinessProvince { get; set; }

        [JsonProperty("business_zip_code")]
        public string BusinessZipCode { get; set; }
    }
}
