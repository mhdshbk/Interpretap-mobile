using Newtonsoft.Json;
using System;

namespace Interpretap.Models
{
    public class CallInfoModel
    {
        [JsonProperty("call_info_id")]
        public string CallInfoId { get; set; }

        [JsonProperty("created_date")]
        public string CreatedDate { get; set; }

        [JsonProperty("call_reference_id")]
        public string CallReferenceId { get; set; }

        [JsonProperty("call_start_date")]
        public string CallStartDate { get; set; }

        [JsonProperty("call_end_date")]
        public string CallEndDate { get; set; }

        [JsonProperty("call_duration")]
        public string CallDuration { get; set; }

        [JsonProperty("call_duration_seconds")]
        public string CallDurationSeconds { get; set; }

        [JsonProperty("client_business_info")]
        public ClientBusinessInfo ClientBusinessInfo { get; set; }

        [JsonProperty("interpreter_business_info")]
        public InterpreterBusinessInfo InterpreterBusinessInfo { get; set; }

        [JsonProperty("client_info")]
        public ClientInfo ClientInfo { get; set; }

        [JsonProperty("interpreter_info")]
        public InterpreterInfo InterpreterInfo { get; set; }

        [JsonProperty("status_info")]
        public string StatusInfo { get; set; }

        [JsonProperty("pause_info")]
        public bool PauseInfo { get; set; }

        [JsonProperty("interpreter_business_billing_info")]
        public InterpreterBusinessBillingInfo InterpreterBusinessBillingInfo { get; set; }

        [JsonProperty("fee_total")]
        public string FeeTotal { get; set; }
    }

    public class ClientBusinessInfo
    {
        [JsonProperty("client_business_id")]
        public string ClientBusinessId { get; set; }

        [JsonProperty("business_id")]
        public string BusinessId { get; set; }

        [JsonProperty("business_name")]
        public string BusinessName { get; set; }
    }

    public class InterpreterBusinessBillingInfo
    {
        [JsonProperty("interpreter_business_id")]
        public string InterpreterBusinessId { get; set; }

        [JsonProperty("fee_amount_per_minute")]
        public string FeeAmountPerMinute { get; set; }

        [JsonProperty("created_date")]
        public string CreatedDate { get; set; }
    }

    public class InterpreterBusinessInfo
    {
        [JsonProperty("interpreter_business_id")]
        public string InterpreterBusinessId { get; set; }

        [JsonProperty("interpreter_origin_business_id")]
        public string InterpreterOriginBusinessId { get; set; }

        [JsonProperty("interpreter_business_name")]
        public string InterpreterBusinessName { get; set; }
    }
}
