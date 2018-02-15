using Interpretap.Models.RespondModels.InnerTypes;
using Interpretap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeProfilePage : ContentPage
    {
        public AgencyEmployeeProfileViewModel VM { get; private set; }

        public EmployeeProfilePage(AgencyInterpreter employee)
        {
            InitializeComponent();

            VM = new AgencyEmployeeProfileViewModel(employee);
            this.BindingContext = VM;

            this.Title = VM.UserName;
        }
    }
}