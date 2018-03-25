using Interpretap.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Interpretap.Common.Constants;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallReportPage : ContentPage
    {
        public CallReportPage(string dateFrom, string dateTo, UserTypes userType)
        {
            InitializeComponent();
            var viewModel = new CallReportViewModel(dateFrom, dateTo, userType);
            this.BindingContext = viewModel;
        }

	}
}