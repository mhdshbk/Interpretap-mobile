using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Interpretap.Models;
using Interpretap.Services;

namespace Interpretap.ViewModels
{
    public class CallQueueViewModel : BaseViewModel
    {

        private ObservableCollection<OpenCallModel> _queueCalls;
        public ObservableCollection<OpenCallModel> QueueCalls
        {
            get { return _queueCalls; }
            set { _queueCalls = value; INotifyPropertyChanged(); }
        }

        public async Task LoadData()
        {
            InterpreterService _interpreterService = new InterpreterService();
            var callResponse = await _interpreterService.FetchOpenCallsResponse(new BaseModel());
            //QueueCalls = new ObservableCollection<OpenCallModel>(callResponse.Calls);
        }
    }
}
