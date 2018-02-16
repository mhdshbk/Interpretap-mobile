using Interpretap.Models;
using Interpretap.Models.RespondModels;
using System;
using System.Threading.Tasks;
using static Interpretap.Common.ConfigApp;

namespace Interpretap.Services
{
    public class AgencyService : BaseServiceNoNulls
    {
        public async Task<FetchCallLogResponse> FetchCallLogs(CallLogRequestModel callLogRequestModel)
        {
            FetchCallLogResponse fetchCallLogResponse = new FetchCallLogResponse();

            try
            {
                fetchCallLogResponse = await Post<FetchCallLogResponse, CallLogRequestModel>(FetchMonthlyCallAmountAgencyAPI, callLogRequestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchCallLogResponse;
        }

        public async Task<FetchFifteenCallsABResponse> FetchFifteenCalls(FifteenCallsRequestModel requestModel)
        {
            FetchFifteenCallsABResponse fetchFifteenCallsResponse = new FetchFifteenCallsABResponse();

            try
            {
                fetchFifteenCallsResponse = await Post<FetchFifteenCallsABResponse, FifteenCallsRequestModel>(FetchFifteenCallsAgencyAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchFifteenCallsResponse;
        }

        public async Task<FetchABReportResponse> FetchAgencyReport(CallReportRequestModel requestModel)
        {
            FetchABReportResponse fetchABReportResponse = new FetchABReportResponse();

            try
            {
                fetchABReportResponse = await Post<FetchABReportResponse, CallReportRequestModel>(FetchAgencyReportAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchABReportResponse;
        }

        public async Task<FetchAgenciesResponce> FetchAssociatedAgencies(BaseModel requestModel)
        {
            FetchAgenciesResponce fetchAssociatedAgenciesResponse = new FetchAgenciesResponce();

            try
            {
                fetchAssociatedAgenciesResponse = await Post<FetchAgenciesResponce, BaseModel>(FetchAssociatedAgenciesAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchAssociatedAgenciesResponse;
        }

        public async Task<BaseRespond> UpdateAgency(AgencyUpdateModel requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await PostNoNulls<BaseRespond, AgencyUpdateModel>(UpdateAgencyAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<AgencyInterpreterRespondModel> FetchInterpretersForAgency(AgencyInterpretersRequestModel request)
        {
            var responce = new AgencyInterpreterRespondModel();

            try
            {
                responce = await Post<AgencyInterpreterRespondModel, AgencyInterpretersRequestModel>(FetchInterpretersAPI, request);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<InterpreterInfoRespondModel> FetchInterpreterInfo(InterpreterInfoRequestModel request)
        {
            var responce = new InterpreterInfoRespondModel();

            try
            {
                responce = await Post<InterpreterInfoRespondModel, InterpreterInfoRequestModel>(FetchInterpreterInfoAPI, request);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }
    }
}
