using Interpretap.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.CustomElements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusinessProfileContentView : ContentView
    {
        public BusinessProfileViewModel ViewModel { get; set; }
        public BusinessProfileContentView()
        {
            InitializeComponent();

            ViewModel = new BusinessProfileViewModel();
            this.BindingContext = ViewModel;
        }

        public void SelectBusiness(int businessId)
        {
            ViewModel.LoadData(businessId);
        }
    }
}