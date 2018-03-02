using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Services;
using Interpretap.Views.InterpreterViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.ViewModels
{
    public class AgenciesViewModel : BaseViewModel
    {
        public ObservableCollection<AgencyModel> Agencies { get; set; }

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                INotifyPropertyChanged();
            }
        }

        public AgenciesViewModel()
        {
            Agencies = new ObservableCollection<AgencyModel>();
        }

        public async Task LoadDataAsync()
        {
            if (Agencies.Count == 0)
            {
                IsBusy = true;
                var callRequestModel = new BaseModel();
                var service = new AgencyService();
                var responce = await service.FetchAssociatedAgencies(callRequestModel);
                foreach (var agency in responce.Agencies)
                {
                    if (agency.IsManager == "1")
                    {
                        Agencies.Add(agency);
                    }
                }
                INotifyPropertyChanged(nameof(Agencies));
                IsBusy = false;

            }
        }

        public void ShowMounthlyCallReportForAgency(AgencyModel agency)
        {
            App.Current.MainPage.Navigation.PushAsync(new AgencyCallsPage(agency));
        }
    }
}
