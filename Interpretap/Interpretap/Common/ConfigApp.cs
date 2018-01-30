namespace Interpretap.Common
{
    public class ConfigApp
    {
        public const string RestApiBaseUrl = "http://www.interpretap.com/interpretap_rest_api/api/";

        public const string LoginUserAPI = RestApiBaseUrl + "user/key_with_login";
        public const string FetchUserAPI = RestApiBaseUrl + "user/fetch_user_info";
        public const string InsertUserAPI = RestApiBaseUrl + "user/insert_user";
        public const string UpdateUserAPI = RestApiBaseUrl + "user/update_user";
        public const string LogoutUserAPI = RestApiBaseUrl + "user/logout";

        public const string FetchFifteenCallsClientAPI = RestApiBaseUrl + "client/fetch_fifteen_calls";
        public const string CreateCallRequestClientAPI = RestApiBaseUrl + "client/create_call_request";
        public const string FetchOpenCallClientAPI = RestApiBaseUrl + "client/fetch_open_call";
        public const string CancelCallClientAPI = RestApiBaseUrl + "client/cancel_call";

        public const string FetchOpenCallsAPI = RestApiBaseUrl + "interpreter/fetch_open_calls";
        public const string FetchFifteenCallsInterpreterAPI = RestApiBaseUrl + "interpreter/fetch_fifteen_calls";
        public const string AssignInterpreterToCallInterpreterAPI = RestApiBaseUrl + "interpreter/assign_interpreter_to_call";
        public const string StartCallInterpreterAPI = RestApiBaseUrl + "interpreter/start_call";
        public const string PauseCallInterpreterAPI = RestApiBaseUrl + "interpreter/start_call_pause";
        public const string EndPauseCallInterpreterAPI = RestApiBaseUrl + "interpreter/end_call_pause";
        public const string EndCallInterpreterAPI = RestApiBaseUrl + "interpreter/end_call";
        public const string CancelCallInterpreterAPI = RestApiBaseUrl + "interpreter/cancel_call";

        public const string FetchFifteenCallsAgencyAPI = RestApiBaseUrl + "agency/fetch_fifteen_calls";
        public const string FetchMonthlyCallAmountAgencyAPI = RestApiBaseUrl + "agency/fetch_monthly_call_amount";
        public const string FetchAgencyReportAPI = RestApiBaseUrl + "agency/fetch_agency_report";
        public const string FetchAssociatedAgenciesAPI = RestApiBaseUrl + "agency/fetch_associated_agencies";

        public const string FetchFifteenCallsBusinessAPI = RestApiBaseUrl + "business/fetch_fifteen_calls";
        public const string FetchMonthlyCallAmountBusinessAPI = RestApiBaseUrl + "business/fetch_monthly_call_amount";
        public const string FetchBusinessReportAPI = RestApiBaseUrl + "business/fetch_client_business_report";
        public const string FetchAssociatedBusinessAPI = RestApiBaseUrl + "business/fetch_associated_businesses";
        
        public const string FetchCallLogAPI = RestApiBaseUrl + "call/fetch_monthly_call_amounts";
        public const string FetchCallAPI = RestApiBaseUrl + "call/fetch_call_info";

        public const string FetchAllLanguagesAPI = RestApiBaseUrl + "misc/fetch_all_languages";

    }
}
