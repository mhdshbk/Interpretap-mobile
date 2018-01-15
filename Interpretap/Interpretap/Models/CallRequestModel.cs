using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.Models
{
    public class CallRequestModel : BaseModel
    {
        [JsonProperty("call_id")]
        public int CallInfoId { get; set; }
    }
}
