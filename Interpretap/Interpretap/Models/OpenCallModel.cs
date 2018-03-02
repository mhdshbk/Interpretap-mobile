using System;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Interpretap.Models
{
    public class OpenCallModel
    {
        public event EventHandler AcceptCallRequested;

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

        public ICommand StartTimerCommand
        {
            get
            {
                return new Command((e) =>
                {
                    AcceptCallRequested?.Invoke(this, new EventArgs());
                });
            }
        }
    }
}
