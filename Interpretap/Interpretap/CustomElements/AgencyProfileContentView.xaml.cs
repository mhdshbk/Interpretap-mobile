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
	public partial class AgencyProfileContentView : ContentView
	{
        public AgencyProfileViewModel ViewModel { get; set; }

        public AgencyProfileContentView ()
		{
			InitializeComponent ();

            ViewModel = new AgencyProfileViewModel();
            this.BindingContext = ViewModel;
		}

        public void SelectAgency(int agencyId)
        {
            ViewModel.LoadData(agencyId);
        }
	}
}