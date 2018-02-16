using Interpretap.Models.RespondModels.InnerTypes;
using Interpretap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views.InterpreterViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeProfilePage : ContentPage
    {
        public AgencyEmployeeProfileViewModel VM { get; private set; }

        public EmployeeProfilePage(AgencyInterpreter employee, int agencyId)
        {
            InitializeComponent();

            VM = new AgencyEmployeeProfileViewModel(employee, agencyId);
            this.BindingContext = VM;

            this.Title = VM.UserName;
        }
    }
}