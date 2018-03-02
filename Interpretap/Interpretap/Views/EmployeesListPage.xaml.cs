using Interpretap.Interfaces.ViewModels;
using Interpretap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesListPage : ContentPage
    {
        EmployeesListBaseViewModel VM;

        public EmployeesListPage(EmployeesListBaseViewModel viewModel)
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

            var selectedItem = lv.SelectedItem as IEmployeeListItemViewModel;
            VM.OnItemSelected(selectedItem);

            lv.SelectedItem = null;
        }

        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var item = e.Item as IEmployeeListItemViewModel;
            VM.OnItemAppearingAsync(item).GetAwaiter();
        }

        private void ListView_ItemDisappearing(object sender, ItemVisibilityEventArgs e)
        {
            VM.OnScrolled();
        }
    }
}