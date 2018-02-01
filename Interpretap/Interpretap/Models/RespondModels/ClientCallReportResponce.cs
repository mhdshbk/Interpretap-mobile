using Interpretap.Interfaces;
using Interpretap.Models.RespondModels.InnerTypes;
using Newtonsoft.Json;

namespace Interpretap.Models.RespondModels
{
    public class ClientCallReportResponce : BaseRespond, ICallReportResponce
    {
        [JsonProperty("client_report")]
        public CallReport Report { get; set; }
    }
}
