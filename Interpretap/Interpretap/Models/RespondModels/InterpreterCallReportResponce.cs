using Interpretap.Interfaces;
using Interpretap.Models.RespondModels.InnerTypes;
using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class InterpreterCallReportResponce : BaseRespond, ICallReportResponce
    {
        [JsonProperty("interpreter_report")]
        public CallReport Report { get; set; }
    }
}
