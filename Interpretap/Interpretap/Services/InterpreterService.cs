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

        public async Task<AssignInterpreterResponce> AssignInterpreterToCall(AssignInterpreterRequestModel requestModel)
        {
            var responce = new AssignInterpreterResponce();

            try
            {
                responce = await Post<AssignInterpreterResponce, AssignInterpreterRequestModel>(AssignInterpreterToCallInterpreterAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> StartCall(BaseInterpreterApiRequest requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, BaseInterpreterApiRequest>(StartCallInterpreterAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> PauseCall(BaseInterpreterApiRequest requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, BaseInterpreterApiRequest>(PauseCallInterpreterAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> UnpauseCall(BaseInterpreterApiRequest requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, BaseInterpreterApiRequest>(EndPauseCallInterpreterAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> EndCall(BaseInterpreterApiRequest requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, BaseInterpreterApiRequest>(EndCallInterpreterAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> CancelCall(BaseInterpreterApiRequest requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, BaseInterpreterApiRequest>(CancelCallInterpreterAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<InterpreterCallReportResponce> FetchMonthReport(CallReportRequestModel requestModel)
        {
            var responce = new InterpreterCallReportResponce();

            try
            {
                responce = await Post<InterpreterCallReportResponce, CallReportRequestModel>(FetchMonthReportInterpreterAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }
    }
}
