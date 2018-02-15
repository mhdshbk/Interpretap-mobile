using Interpretap.Models.RespondModels.InnerTypes;

namespace Interpretap.ViewModels
{
    public class AgencyEmployeesListItemViewModel
    {
        AgencyInterpreter m;

        public string UserName => m.UserName;
        public string FullName => $"{m.InterpreterFirstName} {m.InterpreterLastName}";

        public AgencyEmployeesListItemViewModel(AgencyInterpreter interpreterModel)
        {
            m = interpreterModel;
        }
    }
}
