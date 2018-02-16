using Interpretap.Models.RespondModels.InnerTypes;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;

namespace Interpretap.ViewModels
{
    public class AgencyEmployeeProfileViewModel
    {
        private AgencyInterpreter _employee;

        public string FirstName => _employee.InterpreterFirstName;
        public string LastName => _employee.InterpreterLastName;
        public string UserName => _employee.UserName;
        public string Email => _employee.InterpreterEmail;
        public string PhoneNumber => _employee.InterpreterPhoneNumber;
        public string Address => _employee.InterpreterAddress;
        public string City => _employee.InterpreterCity;
        public string Province => _employee.InterpreterProvince;
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
        
        public AgencyEmployeeProfileViewModel(AgencyInterpreter employee)
        {
            _employee = employee;

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

        private static async Task DeleteEmployeeAsync()
        {
            await App.Current.MainPage.DisplayAlert("Noification", "Under construction", "OK");
        }
    }
}
