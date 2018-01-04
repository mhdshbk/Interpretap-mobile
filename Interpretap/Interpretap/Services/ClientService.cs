using Interpretap.Models;
using Interpretap.Models.RespondModels;
using System;
using static Interpretap.Common.ConfigApp;
using System.Threading.Tasks;

namespace Interpretap.Services
{
    public class ClientService : BaseService
    {
        public async Task<FetchFifteenCallsRespnse> FetchFifteenCalls(FifteenCallsRequestModel requestModel)
        {
            FetchFifteenCallsRespnse fetchFifteenCallsResponse = new FetchFifteenCallsRespnse();

            try
            {
                fetchFifteenCallsResponse = await Post<FetchFifteenCallsRespnse, FifteenCallsRequestModel>(FetchFifteenCallsClientAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchFifteenCallsResponse;
        }
    }
}
