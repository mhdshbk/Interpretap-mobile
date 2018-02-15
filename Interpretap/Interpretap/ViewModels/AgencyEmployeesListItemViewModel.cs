using Interpretap.Models.RespondModels.InnerTypes;

namespace Interpretap.ViewModels
{
    public class AgencyEmployeesListItemViewModel
    {
        public AgencyInterpreter Employee { get; set; }

        public string UserName => Employee.UserName;
        public string FullName => $"{Employee.InterpreterFirstName} {Employee.InterpreterLastName}";

        public AgencyEmployeesListItemViewModel(AgencyInterpreter interpreterModel)
        {
            Employee = interpreterModel;
        }
    }
}
