using Interpretap.Models.RespondModels.InnerTypes;
using Interpretap.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views.UserViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientProfilePage : ContentPage
    {
        BusinessClientViewModel VM;

        public ClientProfilePage(BusinessClient client, BusinessClientsListViewModel parentViewModel)
        {
            InitializeComponent();

            VM = new BusinessClientViewModel(client, parentViewModel);
            this.BindingContext = VM;

            this.Title = VM.UserName;
        }
    }
}