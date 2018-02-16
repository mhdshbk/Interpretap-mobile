using Interpretap.Models;
using Interpretap.Models.RespondModels;
using System;
using static Interpretap.Common.ConfigApp;
using System.Threading.Tasks;

namespace Interpretap.Services
{
    public class BusinessService : BaseServiceNoNulls
    {
        public async Task<FetchCallLogResponse> FetchCallLogs(CallLogRequestModel callLogRequestModel)
        {
            FetchCallLogResponse fetchCallLogResponse = new FetchCallLogResponse();

            try
            {
                fetchCallLogResponse = await Post<FetchCallLogResponse, CallLogRequestModel>(FetchMonthlyCallAmountBusinessAPI, callLogRequestModel);
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
                fetchFifteenCallsResponse = await Post<FetchFifteenCallsABResponse, FifteenCallsRequestModel>(FetchFifteenCallsBusinessAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchFifteenCallsResponse;
        }

        public async Task<FetchABReportResponse> FetchBusinessReport(CallReportRequestModel requestModel)
        {
            FetchABReportResponse fetchABReportResponse = new FetchABReportResponse();

            try
            {
                fetchABReportResponse = await Post<FetchABReportResponse, CallReportRequestModel>(FetchBusinessReportAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchABReportResponse;
        }

        public async Task<FetchBusinessesResponce> FetchAssociatedBusiness(BaseModel requestModel)
        {
            FetchBusinessesResponce fetchAssociatedBusinessResponse = new FetchBusinessesResponce();

            try
            {
                fetchAssociatedBusinessResponse = await Post<FetchBusinessesResponce, BaseModel>(FetchAssociatedBusinessAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return fetchAssociatedBusinessResponse;
        }

        public async Task<BaseRespond> UpdateBusiness(BusinessUpdateModel requestModel)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await PostNoNulls<BaseRespond, BusinessUpdateModel>(UpdateBusinessAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BusinessClientsRespondModel> FetchClientsForBusiness(BusinessClientsRequestModel requestModel)
        {
            var responce = new BusinessClientsRespondModel();

            try
            {
                responce = await Post<BusinessClientsRespondModel, BusinessClientsRequestModel>(FetchClientsAPI, requestModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> RemoveClientFromBusiness(RemoveClientFromBusinessRequestModel request)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, RemoveClientFromBusinessRequestModel>(RemoveClientFromBusinessAPI, request);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }

        public async Task<BaseRespond> AddClientToBusiness(AddClientToBusinessRequestModel request)
        {
            var responce = new BaseRespond();

            try
            {
                responce = await Post<BaseRespond, AddClientToBusinessRequestModel>(AddClientToBusinessAPI, request);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return responce;
        }
    }
}
