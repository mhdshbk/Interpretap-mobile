using Interpretap.Models;
using Interpretap.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ActiveCallViewModel
    {
        public event EventHandler CallCanceled;

        public bool IsVisible { get; set; }
        public bool IsActivityIndicatorVisible { get; set; }

        public string CallId { get; set; }

        public ICommand CancelCallCommand { get; set; }
        public bool CancelCallCommandCanExecute { get; set; }

        public ActiveCallViewModel()
        {
            CancelCallCommand = new Command(async () => await ExecuteCancelCallAsync());
        }

        private async Task ExecuteCancelCallAsync()
        {
            CancelCallCommandCanExecute = false;
            var service = new ClientService();
            var request = new CancelCallRequestModel();
            request.CallId = CallId;
            var responce = await service.CancelCallRequest(request);
            if (responce.Status == true)
            {
                IsVisible = false;
                CallCanceled?.Invoke(this, new EventArgs());
            }
        }

        async Task GetRequestedCallAsync()
        {
            try
            {
                IsVisible = true;
                IsActivityIndicatorVisible = true;

                var service = new ClientService();
                var request = new BaseModel();
                var responce = await service.FetchOpenCallRequest(request);

                var callExists = responce.CallId != "0";
                IsVisible = callExists;
                CancelCallCommandCanExecute = callExists;

                CallId = responce.CallId;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                IsActivityIndicatorVisible = false;
            }
        }

        public void OnAppearing()
        {
            GetRequestedCallAsync();
        }
    }
}
