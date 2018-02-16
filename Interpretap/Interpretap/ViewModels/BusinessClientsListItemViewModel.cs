using Interpretap.Interfaces.ViewModels;
using Interpretap.Models.RespondModels.InnerTypes;

namespace Interpretap.ViewModels
{
    public class BusinessClientsListItemViewModel : IEmployeeListItemViewModel
    {
        public BusinessClient Client { get; set; }

        public string UserName => Client.UserName;
        public string FullName => $"{Client.ClientFirstName} {Client.ClientLastName}";

        public BusinessClientsListItemViewModel(BusinessClient clientModel)
        {
            Client = clientModel;
        }
    }
}
