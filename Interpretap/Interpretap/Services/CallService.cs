using Interpretap.Models;
using Interpretap.Models.RespondModels;
using System;
using System.Threading.Tasks;
using static Interpretap.Common.ConfigApp;

namespace Interpretap.Services
{
    class CallService : BaseService
    {
        public async Task<FetchCallLogResponse> FetchCallLogs(CallLogRequestModel callLogRequestModel)
        {
            FetchCallLogResponse fetchCallLogResponse = new FetchCallLogResponse();

            try
            {
                fetchCallLogResponse = await Post<FetchCallLogResponse, CallLogRequestModel>(FetchCallLogAPI, callLogRequestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchCallLogResponse;
        }
    }
}
