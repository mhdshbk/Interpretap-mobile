using System;
using System.Threading.Tasks;
using Interpretap.Models;
using Interpretap.Models.RespondModels;
using static Interpretap.Common.ConfigApp;

namespace Interpretap.Services
{
    public class InterpreterService : BaseService
    {
        public async Task<FetchOpenCallsResponse> FetchOpenCalls(BaseModel baseModel)
        {
            FetchOpenCallsResponse fetchOpenCallsResponse = new FetchOpenCallsResponse();

            try
            {
                fetchOpenCallsResponse = await Post<FetchOpenCallsResponse, BaseModel>(FetchOpenCallsAPI, baseModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchOpenCallsResponse;
        }

        public async Task<FetchFifteenCallsRespnse> FetchFifteenCalls(FifteenCallsRequestModel requestModel)
        {
            FetchFifteenCallsRespnse fetchFifteenCallsResponse = new FetchFifteenCallsRespnse();

            try
            {
                fetchFifteenCallsResponse = await Post<FetchFifteenCallsRespnse, FifteenCallsRequestModel>(FetchFifteenCallsInterpreterAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchFifteenCallsResponse;
        }
    }
}
