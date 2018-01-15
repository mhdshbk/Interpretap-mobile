using Interpretap.Models;
using Interpretap.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallInfo : ContentPage
    {
        CallInfoViewModel _viewModel;

        public CallInfo(FifteenCallModel call)
        {
            InitializeComponent();
            _viewModel = new CallInfoViewModel(call);
            this.BindingContext = _viewModel;
        }
    }
}