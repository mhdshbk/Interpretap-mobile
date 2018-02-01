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

        public async Task<CreateCallRequestResponce> CreateCallRequest(CreateCallRequestModel requestModel)
        {
            var responce = new CreateCallRequestResponce();

            try
            {
                responce = await Post<CreateCallRequestResponce, CreateCallRequestModel>(CreateCallRequestClientAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<FetchCurrentCallResponce> FetchCurrentCall(BaseModel requestModel)
        {
            var responce = new FetchCurrentCallResponce();

            try
            {
                responce = await Post<FetchCurrentCallResponce, BaseModel>(FetchCurrentCallClientAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> CancelCallRequest(CancelCallRequestModel requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, CancelCallRequestModel>(CancelCallClientAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<ClientCallReportResponce> FetchMonthReport(CallReportRequestModel requestModel)
        {
            var responce = new ClientCallReportResponce();

            try
            {
                responce = await Post<ClientCallReportResponce, CallReportRequestModel>(FetchMonthReportClientAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

    }
}
