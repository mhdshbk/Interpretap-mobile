using Newtonsoft.Json;
using System.Text;

namespace Interpretap.Models.RespondModels
{
    public class BaseRespond
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        public string GetMessage(bool ignoreErrors = false)
        {
            var sb = new StringBuilder();
            sb.AppendLine(Message);
            if (ignoreErrors || Errors == null)
            {
                return sb.ToString();
            }
            else
            {
                foreach (var errorMessage in Errors)
                {
                    sb.AppendLine($"- {errorMessage}");
                }
                return sb.ToString();
            }
        }
    }
}
