using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Interpretap.Models
{
    public class FifteenCallModel
    {
        [JsonProperty("call_info_id")]
        public int CallInfoId { get; set; }

        [JsonProperty("call_status_id")]
        public int CallStatusId { get; set; }

        [JsonProperty("call_ref_id")]
        public string CallRefId { get; set; }

        [JsonProperty("client_id")]
        public int? ClientId { get; set; }

        [JsonProperty("interpreter_id")]
        public int? InterpreterId { get; set; }

        [JsonProperty("client_language_id")]
        public int ClientLanguageId { get; set; }

        [JsonProperty("requested_language_id")]
        public int RequestedLanguageId { get; set; }

        [JsonProperty("start_call_date")]
        public string StartCallDate { get; set; }

        [JsonProperty("end_call_date")]
        public string EndCallDate { get; set; }

        [JsonProperty("canceled_date")]
        public string CaneledDate { get; set; }

        [JsonProperty("created_date")]
        public string CreatedDate { get; set; }

        [JsonProperty("modified_date")]
        public string ModifitedDate { get; set; }

        [JsonProperty("created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty("modified_by")]
        public int ModifitedBy { get; set; }

        [JsonProperty("client_business_id")]
        public int? ClientBusinessId { get; set; }

        [JsonProperty("call_client_first_name")]
        public string FirstName { get; set; }

        [JsonProperty("call_client_last_name")]
        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public string ClientName { get { return $"{ClientInfo?.ClientFirstName} {ClientInfo?.ClientLastName}"; } }

        [JsonProperty("call_duration")]
        public string CallDuration { get; set; }

        [JsonProperty("call_duration_seconds")]
        public int? CallDurationSeconds { get; set; }

        [JsonProperty("status_info")]
        public String StatusInfo { get; set; }

        [JsonProperty("client_info")]
        public ClientInfo ClientInfo { get; set; }

        [JsonProperty("interpreter_info")]
        public InterpreterInfo InterpreterInfo { get; set; }

        public ICommand OpebSingleCallCommand
        {
            get
            {
                return new Command((e) =>
                {
                    Application.Current.MainPage.Navigation.PushAsync(new Views.InterpreterViews.TimerPage());
                });
            }
        }
    }
}
