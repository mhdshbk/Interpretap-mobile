using Interpretap.Interfaces.ViewModels;
using Interpretap.Models;
using Interpretap.Models.RespondModels.InnerTypes;
using Interpretap.Services;
using Interpretap.Views.InterpreterViews;
using PropertyChanged;
using System.Threading.Tasks;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AgencyInterpretersListViewModel : EmployeesListBaseViewModel
    {
        public int AgencyId { get; private set; }

        public AgencyInterpretersListViewModel(int agencyId) : base()
        {
            AgencyId = agencyId;
        }

        protected override async Task ExecuteAddCommandAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddInterpreterToAgencyPage(this));
        }

        protected override async Task LoadDataAsync()
        {
            IsRefreshing = true;

            var interpreters = await FetchDataAsync();
            FillEmployeesList(interpreters);
            IsRefreshing = false;
        }

        private void FillEmployeesList(AgencyInterpreter[] interpreters)
        {
            if (interpreters != null)
            {
                foreach (var i in interpreters)
                {
                    var itemVM = new AgencyInterpretersListItemViewModel(i);
                    Employees.Add(itemVM);
                }
            }
        }

        private async Task<AgencyInterpreter[]> FetchDataAsync()
        {
            var request = new AgencyInterpretersRequestModel()
            {
                AgencyId = AgencyId.ToString(),
                FromInterpreterId = string.Empty,
            };

            var service = new AgencyService();
            var responce = await service.FetchInterpretersForAgency(request);
            return responce.AgencyInterpreters;
        }

        public override void OnItemSelected(IEmployeeListItemViewModel selectedItem)
        {
            var item = selectedItem as AgencyInterpretersListItemViewModel;
            App.Current.MainPage.Navigation.PushAsync(new EmployeeProfilePage(item.Employee, this));
        }
    }
}
