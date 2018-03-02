﻿namespace Interpretap.Common
{
    public class ConfigApp
    {
        public const string RestApiBaseUrl = "http://www.interpretap.com/interpretap_rest_api/api/";

        public const string LoginUserAPI = RestApiBaseUrl + "user/key_with_login";
        public const string FetchUserAPI = RestApiBaseUrl + "user/fetch_user_info";
        public const string InsertUserAPI = RestApiBaseUrl + "user/insert_user";
        public const string UpdateUserAPI = RestApiBaseUrl + "user/update_user";
        public const string LogoutUserAPI = RestApiBaseUrl + "user/logout";
        public const string FetchCurrentCallUserAPI = RestApiBaseUrl + "user/fetch_current_call_info";
        public const string UpdateDeviceIdUserAPI = RestApiBaseUrl + "user/update_device_id";
        public const string RateUserAPI = RestApiBaseUrl + "user/rate_user";
        public const string ResetPasswordUserAPI = RestApiBaseUrl + "user/reset_password";
        public const string ForgotPasswordUserAPI = RestApiBaseUrl + "user/forgot_password";

        public const string FetchFifteenCallsClientAPI = RestApiBaseUrl + "client/fetch_fifteen_calls";
        public const string CreateCallRequestClientAPI = RestApiBaseUrl + "client/create_call_request";
        public const string CancelCallClientAPI = RestApiBaseUrl + "client/cancel_call";
        public const string FetchMonthReportClientAPI = RestApiBaseUrl + "client/fetch_client_report";

        public const string FetchOpenCallsAPI = RestApiBaseUrl + "interpreter/fetch_open_calls";
        public const string FetchFifteenCallsInterpreterAPI = RestApiBaseUrl + "interpreter/fetch_fifteen_calls";
        public const string AssignInterpreterToCallInterpreterAPI = RestApiBaseUrl + "interpreter/assign_interpreter_to_call";
        public const string StartCallInterpreterAPI = RestApiBaseUrl + "interpreter/start_call";
        public const string PauseCallInterpreterAPI = RestApiBaseUrl + "interpreter/start_call_pause";
        public const string EndPauseCallInterpreterAPI = RestApiBaseUrl + "interpreter/end_call_pause";
        public const string EndCallInterpreterAPI = RestApiBaseUrl + "interpreter/end_call";
        public const string CancelCallInterpreterAPI = RestApiBaseUrl + "interpreter/cancel_call";
        public const string FetchMonthReportInterpreterAPI = RestApiBaseUrl + "interpreter/fetch_interpreter_report";

        public const string FetchFifteenCallsAgencyAPI = RestApiBaseUrl + "agency/fetch_fifteen_calls";
        public const string FetchMonthlyCallAmountAgencyAPI = RestApiBaseUrl + "agency/fetch_monthly_call_amount";
        public const string FetchAgencyReportAPI = RestApiBaseUrl + "agency/fetch_agency_report";
        public const string FetchAssociatedAgenciesAPI = RestApiBaseUrl + "agency/fetch_associated_agencies";
        public const string UpdateAgencyAPI = RestApiBaseUrl + "agency/update_agency";
        public const string FetchInterpretersAPI = RestApiBaseUrl + "agency/fetch_agency_interpreters";
        public const string FetchInterpreterInfoAPI = RestApiBaseUrl + "agency/fetch_interpreter_employee_info";
        public const string AddInterpreterToAgencyAPI = RestApiBaseUrl + "agency/add_interpreter_to_agency";
        public const string RemoveInterpreterFromAgencyAPI = RestApiBaseUrl + "agency/remove_interpreter_from_agency";

        public const string FetchFifteenCallsBusinessAPI = RestApiBaseUrl + "business/fetch_fifteen_calls";
        public const string FetchMonthlyCallAmountBusinessAPI = RestApiBaseUrl + "business/fetch_monthly_call_amount";
        public const string FetchBusinessReportAPI = RestApiBaseUrl + "business/fetch_client_business_report";
        public const string FetchAssociatedBusinessAPI = RestApiBaseUrl + "business/fetch_associated_businesses";
        public const string UpdateBusinessAPI = RestApiBaseUrl + "business/update_business";
        public const string FetchClientsAPI = RestApiBaseUrl + "business/fetch_business_clients";
        public const string RemoveClientFromBusinessAPI = RestApiBaseUrl + "business/remove_client_from_business";
        public const string AddClientToBusinessAPI = RestApiBaseUrl + "business/add_client_to_business";

        public const string FetchCallLogAPI = RestApiBaseUrl + "call/fetch_monthly_call_amounts";
        public const string FetchCallAPI = RestApiBaseUrl + "call/fetch_call_info";

        public const string FetchAllLanguagesAPI = RestApiBaseUrl + "misc/fetch_all_languages";
        public const string NotifyCrashAPI = RestApiBaseUrl + "misc/notify_crash";

    }
}
