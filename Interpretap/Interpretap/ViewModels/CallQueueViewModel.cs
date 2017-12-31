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

        public CallQueueViewModel()
        {
            _queueCalls = new ObservableCollection<OpenCallModel>();
        }

        public async Task LoadData()
        {
            InterpreterService _interpreterService = new InterpreterService();
            var callResponse = await _interpreterService.FetchOpenCalls(new BaseModel());
            foreach (var call in callResponse.Calls)
                QueueCalls.Add(call);
        }
    }
}
