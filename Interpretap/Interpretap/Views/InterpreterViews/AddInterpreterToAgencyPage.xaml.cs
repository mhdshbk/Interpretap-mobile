using Interpretap.Models;
using Interpretap.Services;
using PropertyChanged;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views.InterpreterViews
{
    [AddINotifyPropertyChangedInterface]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddInterpreterToAgencyPage : ContentPage
    {
        int _agencyId;
        public bool IsProcessing { get; private set; }
        public bool CanAddInterpreter { get; private set; } 

        public AddInterpreterToAgencyPage(int agencyId)
        {
            _agencyId = agencyId;
            InitializeComponent();

            this.BindingContext = this;
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            AddInterpreterToAgencyAsync();
        }

        private async Task AddInterpreterToAgencyAsync()
        {
            IsProcessing = true;

            var request = new AddInterpreterToAgencyRequestModel()
            {
                AgencyId = _agencyId.ToString(),
                InterpreterId = lblId.Text,
                IsManager = SwitchIsManager.IsToggled ? "1" : "0",
            };

            var service = new AgencyService();
            var responce = await service.AddInterpreterToAgency(request);

            IsProcessing = false;

            var success = responce.Status == true;
            if (success)
            {
                await App.Current.MainPage.DisplayAlert("Success", responce.Message, "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", responce.Message, "OK");
            }
        }

        private void lblId_TextChanged(object sender, TextChangedEventArgs e)
        {
            CanAddInterpreter = !string.IsNullOrEmpty(lblId.Text);
}
    }
}