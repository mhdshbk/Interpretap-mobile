﻿using Interpretap.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Interpretap.ViewModels
{
    public class RateUserViewModel : INotifyPropertyChanged
    {
        private RateUserModel _model;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Rating { get; set; }

        public ICommand RateCommand { get; set; }
        public bool CanExecuteRateCommand => Rating != null;

        public bool IsProcessing { get; set; }

        public RateUserViewModel(RateUserModel model)
        {
            _model = model;

            RateCommand = new Command(async () => await ExecuteRateCommandAsync());
        }

        private async Task ExecuteRateCommandAsync()
        {
            IsProcessing = true;

            var result = await _model.RateUserAsync(Rating);
            var isSuccess = result.Status == true;

            IsProcessing = false;

            if (!isSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", result.GetMessage(), "OK");
            }
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
