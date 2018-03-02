﻿using Interpretap.Models;
using PropertyChanged;
using System;
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
        public string CallBusinessName { get; set; }
        public string CallCreatedDate { get; set; }

        public ICommand CancelCallCommand { get; set; }
        public bool CancelCallCommandCanExecute { get; set; }

        public ActiveCallViewModel()
        {
            CancelCallCommand = new Command(async () => await ExecuteCancelCallAsync());
            App.ActiveCall.PropertyChanged += ActiveCall_PropertyChanged;
        }

        private void ActiveCall_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(App.ActiveCall.ActiveCallRequest))
            {
                GetRequestedCallAsync();
            }
        }

        private async Task ExecuteCancelCallAsync()
        {
            IsActivityIndicatorVisible = true;
            CancelCallCommandCanExecute = false;

            var request = new CancelCallRequestModel
            {
                CallId = CallId
            };
            var responce = await App.ActiveCall.CancelActiveCall(request);
            if (responce.Status == true)
            {
                IsVisible = false;
                CallCanceled?.Invoke(this, new EventArgs());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", responce.GetMessage(), "OK");
            }
            IsActivityIndicatorVisible = false;
        }

        async Task GetRequestedCallAsync()
        {
            try
            {
                IsVisible = true;
                IsActivityIndicatorVisible = true;
                
                var callRequest = await App.ActiveCall.GetActiveCallRequestAsync();

                var callExists = callRequest.Status == true;
                IsVisible = callExists;
                CancelCallCommandCanExecute = callExists;
                
                if (callExists)
                {
                    CallId = callRequest.CallId;
                    CallBusinessName = callRequest.CallInfo.ClientBusinessInfo.BusinessName;
                    CallCreatedDate = callRequest.CallInfo.CallDetails.CreatedDate.ToString("yyyy-MM-dd hh:mm:ss");
                }
                else
                {
                    CallId = "0";
                    CallBusinessName = string.Empty;
                    CallCreatedDate = "0000-00-00 00:00:00";
                }
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
