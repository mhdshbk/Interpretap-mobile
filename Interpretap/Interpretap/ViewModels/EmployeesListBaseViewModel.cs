using Interpretap.Models;
using Interpretap.Models.RespondModels.InnerTypes;
using Interpretap.Services;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseEmployeesListViewModel
    {
        int _agencyId;

        public ObservableCollection<AgencyEmployeesListItemViewModel> Employees { get; set; }

        public bool IsRefreshing { get; set; }
        public ICommand RefreshCommand { get; set; }

        public BaseEmployeesListViewModel(int agencyId)
        {
            _agencyId = agencyId;
            Employees = new ObservableCollection<AgencyEmployeesListItemViewModel>();
            RefreshCommand = new Command(async () => await ExecuteRefreshCommandAsync());
        }

        private async Task ExecuteRefreshCommandAsync()
        {
            Employees.Clear();
            await LoadDataAsync();
        }

        async Task LoadDataAsync()
        {
            IsRefreshing = true;

            var interpreters = await FetchDataAsync();
            foreach (var i in interpreters)
            {
                var itemVM = new AgencyEmployeesListItemViewModel(i);
                Employees.Add(itemVM);
            }

            IsRefreshing = false;
        }

        private async Task<AgencyInterpreter[]> FetchDataAsync()
        {
            var request = new AgencyInterpretersRequestModel()
            {
                AgencyId = _agencyId.ToString(),
                FromInterpreterId = string.Empty,
            };

            var service = new AgencyService();
            var responce = await service.FetchInterpretersForAgency(request);
            return responce.AgencyInterpreters;
        }

        public void OnAppearing()
        {
            LoadDataAsync();
        }
    }
}
