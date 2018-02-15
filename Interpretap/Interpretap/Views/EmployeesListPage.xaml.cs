using Interpretap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesListPage : ContentPage
    {
        BaseEmployeesListViewModel VM;

        public EmployeesListPage(int agencyId)
        {
            InitializeComponent();
            VM = new BaseEmployeesListViewModel(agencyId);
            this.BindingContext = VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            VM.OnAppearing();
        }
    }
}