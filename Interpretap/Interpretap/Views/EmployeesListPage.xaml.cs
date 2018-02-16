using Interpretap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesListPage : ContentPage
    {
        AgencyInterpretersListViewModel VM;

        public EmployeesListPage(AgencyInterpretersListViewModel viewModel)
        {
            InitializeComponent();
            VM = viewModel;
            this.BindingContext = VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            VM.OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var lv = sender as ListView;
            if (lv.SelectedItem == null) return;

            var selectedItem = lv.SelectedItem as AgencyInterpretersListItemViewModel;
            VM.OnItemSelected(selectedItem);

            lv.SelectedItem = null;
        }
    }
}