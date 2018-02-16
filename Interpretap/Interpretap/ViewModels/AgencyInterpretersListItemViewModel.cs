using Interpretap.Interfaces.ViewModels;
using Interpretap.Models.RespondModels.InnerTypes;

namespace Interpretap.ViewModels
{
    public class AgencyInterpretersListItemViewModel : IEmployeeListItemViewModel
    {
        public AgencyInterpreter Employee { get; set; }

        public string UserName => Employee.UserName;
        public string FullName => $"{Employee.InterpreterFirstName} {Employee.InterpreterLastName}";

        public AgencyInterpretersListItemViewModel(AgencyInterpreter interpreterModel)
        {
            Employee = interpreterModel;
        }
    }
}
