using Interpretap.Models;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Interpretap.Core
{
    public class ActiveCallModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public FetchCurrentCallResponce ActiveCallRequest { get; set; }
        public bool ActiveCallExist => ActiveCallRequest != null ? ActiveCallRequest.Status == true : false;

        public async Task FetchActiveCallRequestAsync()
        {
            var service = new UserService();
            var request = new BaseModel();
            var responce = await service.FetchCurrentCall(request);
            ActiveCallRequest = responce;
        }

        public async Task<FetchCurrentCallResponce> GetActiveCallRequestAsync()
        {
            if (ActiveCallRequest==null)
            {
                await FetchActiveCallRequestAsync();
            }
            return ActiveCallRequest;
        }

        public async Task<CreateCallRequestResponce> RequestNewCall(CreateCallRequestModel request)
        {
            var service = new ClientService();
            var responce = await service.CreateCallRequest(request);
            FetchActiveCallRequestAsync();
            return responce;
        }

        public async Task<BaseRespond> CancelActiveCall(CancelCallRequestModel request)
        {
            var service = new ClientService();
            var responce = await service.CancelCallRequest(request);
            FetchActiveCallRequestAsync();
            return responce;
        }
    }
}
