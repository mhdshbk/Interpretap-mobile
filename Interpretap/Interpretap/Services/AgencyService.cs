using Interpretap.Models;
using Interpretap.Models.RespondModels;
using System;
using static Interpretap.Common.ConfigApp;
using System.Threading.Tasks;

namespace Interpretap.Services
{
    public class AgencyService : BaseService
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
    }
}
