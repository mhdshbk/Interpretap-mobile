using System.Threading.Tasks;
using System.Windows.Input;
using Interpretap.Models;
using Interpretap.Models.RespondModels.InnerTypes;
using Interpretap.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Interpretap.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AgencyEmployeeProfileViewModel
    {
        private AgencyInterpreter _employee;
        private int _agencyId;
        AgencyInterpretersListViewModel _parentViewModel;

        public string FirstName => _employee.InterpreterFirstName;
        public string LastName => _employee.InterpreterLastName;
        public string UserName => _employee.UserName;
        public string Email => _employee.InterpreterEmail;
        public string PhoneNumber => _employee.InterpreterPhoneNumber;
        public string Address => _employee.InterpreterAddress + "\n" + _employee.InterpreterCity + "\n" + _employee.InterpreterProvince;
        //public string City => _employee.InterpreterCity;
        //public string Province => _employee.InterpreterProvince;
        public string Id => _employee.InterpreterId;
        public string IsManager
        {
            get
            {
                if (_employee.IsManager == "1")
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }

            }
        }

        public ICommand DeleteCommand { get; set; }

        public bool IsProcessing { get; private set; }

        public AgencyEmployeeProfileViewModel(AgencyInterpreter employee, AgencyInterpretersListViewModel parentViewModel)
        {
            _employee = employee;
            _agencyId = parentViewModel.AgencyId;
            _parentViewModel = parentViewModel;

            DeleteCommand = new Command(async () => await ExecuteDeleteEmployeeCommandAsync());
        }

        private async Task ExecuteDeleteEmployeeCommandAsync()
        {
            var confirmed = await App.Current.MainPage.DisplayAlert("Warning", "Are you sure?", "Yes", "No");
            if (confirmed)
            {
                await DeleteEmployeeAsync();
            }
        }

        private async Task DeleteEmployeeAsync()
        {
            IsProcessing = true;

            var request = new RemoveInterpreterFromAgencyRequestModel()
            {
                AgencyId = _agencyId.ToString(),
                InterpreterId = _employee.InterpreterId,
            };
            var service = new AgencyService();
            var responce = await service.RemoveInterpreterFromAgency(request);

            IsProcessing = false;

            var success = responce.Status == true;
            if (success)
            {
                _parentViewModel.RefreshCommand.Execute(null);
                await App.Current.MainPage.DisplayAlert("Success", responce.GetMessage(), "OK");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", responce.GetMessage(), "OK");
            }
        }

        private async Task GetEmployeeInfoAsync()
        {
            IsProcessing = true;

            var request = new InterpreterInfoRequestModel()
            {
                InterpreterId = _employee.InterpreterId
            };
            var service = new AgencyService();
            var result = await service.FetchInterpreterInfo(request);

            IsProcessing = false;
        }
    }
}
