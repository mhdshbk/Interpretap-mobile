using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.Models
{
    public class ExceptionDataModel : BaseModel
    {
        [JsonProperty("exception_message")]
        public string Message { get; set; }

        [JsonProperty("exception_stack_trace")]
        public string StackTrace { get; set; }

        [JsonProperty("inner_exception_message")]
        public string InnerMessage { get; set; }

        [JsonProperty("inner_exception_stack_trace")]
        public string InnerStackTrace { get; set; }
    }
}
