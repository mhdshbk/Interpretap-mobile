using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels.InnerTypes
{
    public class AgencyInterpreter
    {
        [JsonProperty("interpreter_first_name")]
        public string InterpreterFirstName { get; set; }

        [JsonProperty("interpreter_last_name")]
        public string InterpreterLastName { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("interpreter_email")]
        public string InterpreterEmail { get; set; }

        [JsonProperty("interpreter_phone_number")]
        public string InterpreterPhoneNumber { get; set; }

        [JsonProperty("interpreter_address")]
        public string InterpreterAddress { get; set; }

        [JsonProperty("interpreter_city")]
        public string InterpreterCity { get; set; }

        [JsonProperty("interpreter_province")]
        public string InterpreterProvince { get; set; }

        [JsonProperty("interpreter_id")]
        public string InterpreterId { get; set; }

        [JsonProperty("is_manager")]
        public string IsManager { get; set; }
    }
}
