using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Services;
using Interpretap.Views.InterpreterViews;
using Interpretap.Views.UserViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.ViewModels
{
    public class BusinessesViewModel : BaseViewModel
    {
        public ObservableCollection<BusinessModel> Businesses { get; set; }

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

        public BusinessesViewModel()
        {
            Businesses = new ObservableCollection<BusinessModel>();
        }

        public async Task LoadDataAsync()
        {
            if (Businesses.Count == 0)
            {
                IsBusy = true;
                var callRequestModel = new BaseModel();
                var service = new BusinessService();
                var responce = await service.FetchAssociatedBusiness(callRequestModel);
                foreach (var business in responce.Businesses)
                {
                    if (business.IsManager == "1")
                    {
                        Businesses.Add(business);
                    }
                }
                INotifyPropertyChanged(nameof(Businesses));
                IsBusy = false;

            }
        }

        public void ShowMounthlyCallReportForBusiness(BusinessModel business)
        {
            App.Current.MainPage.Navigation.PushAsync(new BusinessCallsPage(business));
        }
    }
}
