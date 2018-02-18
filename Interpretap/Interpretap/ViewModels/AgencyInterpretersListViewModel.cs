using Interpretap.Interfaces.ViewModels;
using Interpretap.Models;
using Interpretap.Models.RespondModels.InnerTypes;
using Interpretap.Services;
using Interpretap.Views.InterpreterViews;
using PropertyChanged;
using System.Linq;
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

        protected override async Task<int> LoadDataAsync(string fromId = "")
        {
            IsRefreshing = true;

            var interpreters = await FetchDataAsync(fromId);
            FillEmployeesList(interpreters);
            IsRefreshing = false;

            return interpreters.Count();
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

        private async Task<AgencyInterpreter[]> FetchDataAsync(string fromId)
        {
            var request = new AgencyInterpretersRequestModel()
            {
                AgencyId = AgencyId.ToString(),
                FromInterpreterId = fromId,
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

        public override async Task OnItemAppearingAsync(IEmployeeListItemViewModel item)
        {
            if (!ToPaginate) return;

            var client = item as AgencyInterpretersListItemViewModel;
            var clientIsLastVisible = client == Employees.Last();
            if (clientIsLastVisible)
            {
                var fromId = client.Employee.InterpreterId;
                var countNew = await LoadDataAsync(fromId);
                if (countNew == 0)
                {
                    ToPaginate = false;
                }
            }

        }
    }
}
