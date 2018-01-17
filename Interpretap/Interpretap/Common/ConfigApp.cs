namespace Interpretap.Common
{
    public class ConfigApp
    {
        public const string RestApiBaseUrl = "http://www.interpretap.com/interpretap_rest_api/api/";

        public const string LoginUserAPI = RestApiBaseUrl + "user/key_with_login";
        public const string FetchUserAPI = RestApiBaseUrl + "user/fetch_user_info";
        public const string InsertUserAPI = RestApiBaseUrl + "user/insert_user";
        public const string UpdateUserAPI = RestApiBaseUrl + "user/update_user";

        public const string FetchFifteenCallsClientAPI = RestApiBaseUrl + "client/fetch_fifteen_calls";

        public const string FetchOpenCallsAPI = RestApiBaseUrl + "interpreter/fetch_open_calls";
        public const string FetchFifteenCallsInterpreterAPI = RestApiBaseUrl + "interpreter/fetch_fifteen_calls";

        public const string FetchFifteenCallsAgencyAPI = RestApiBaseUrl + "agency/fetch_fifteen_calls";
        public const string FetchMonthlyCallAmountAgencyAPI = RestApiBaseUrl + "agency/fetch_monthly_call_amount";
        public const string FetchAgencyReportAPI = RestApiBaseUrl + "agency/fetch_agency_report";
        public const string FetchAssociatedAgenciesAPI = RestApiBaseUrl + "agency/fetch_associated_agencies";

        public const string FetchFifteenCallsBusinessAPI = RestApiBaseUrl + "business/fetch_fifteen_calls";
        public const string FetchMonthlyCallAmountBusinessAPI = RestApiBaseUrl + "business/fetch_monthly_call_amount";
        public const string FetchBusinessReportAPI = RestApiBaseUrl + "business/fetch_client_business_report";

        public const string FetchCallLogAPI = RestApiBaseUrl + "call/fetch_monthly_call_amounts";
        public const string FetchCallAPI = RestApiBaseUrl + "call/fetch_call_info";

    }
}
