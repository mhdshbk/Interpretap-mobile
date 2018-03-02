using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class InterpreterInfoRespondModel
    {
        [JsonProperty("interpreter_employee_info")]
        public InterpreterEmployeeInfo InterpreterEmployeeInfo { get; set; }
    }

    public partial class InterpreterEmployeeInfo
    {
        [JsonProperty("interpreter_id")]
        public string InterpreterId { get; set; }

        [JsonProperty("user_info")]
        public UserModel UserInfo { get; set; }
    }
}
