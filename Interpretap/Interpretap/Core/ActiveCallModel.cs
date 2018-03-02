﻿using Interpretap.Models;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using static Interpretap.Common.ConfigApp;
using static Interpretap.Common.Constants;

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
            if (ActiveCallRequest == null)
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

        public void OnAppCrash()
        {
            if (ActiveCallRequest.CallId == null) return;
            if (App.User.UserType == UserTypes.Client)
            {
                OnAppCrashClient();
            }
            if (App.User.UserType == UserTypes.Interpreter)
            {
                OnAppCrashInterpreter();
            }
        }

        private void OnAppCrashClient()
        {
            var request = new CancelCallRequestModel()
            {
                CallId = ActiveCallRequest.CallId
            };
            var syncService = new SyncService();
            syncService.Post(CancelCallClientAPI, request);
        }

        private void OnAppCrashInterpreter()
        {
            var request = new BaseInterpreterApiRequest()
            {
                CallId = ActiveCallRequest.CallId
            };
            var syncService = new SyncService();
            syncService.Post(PauseCallInterpreterAPI, request);
        }
    }
}
