using Interpretap.Models;
using Interpretap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Interpretap.Common.Constants;

namespace Interpretap.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportPage : ContentPage
	{
        private ABCallReportViewModel _viewModel { get; set; }
        private MonthlyCallReportModel _monthlyCallReportModel;
        private UserTypes _userType;

        public AgencyModel Agency
        {
            get => _viewModel?.Agency;
            set
            {
                if (value != _viewModel.Agency)
                {
                    _viewModel.Agency = value;
                }
            }
        }
        public BusinessModel Business
        {
            get => _viewModel?.Business;
            set
            {
                if (value != _viewModel.Business)
                {
                    _viewModel.Business = value;
                }
            }
        }

        public ReportPage (MonthlyCallReportModel monthlyCallReportModel, UserTypes userType)
		{
            InitializeComponent ();

            _monthlyCallReportModel = monthlyCallReportModel;
            _userType = userType;
            Lbl_FromTo.Text = _monthlyCallReportModel.DateFromTo;

            _viewModel = new ABCallReportViewModel();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_monthlyCallReportModel != null)
                _viewModel.LoadData(_monthlyCallReportModel.StartOfMonth,
                    _monthlyCallReportModel.EndOfMonth,
                    _userType).GetAwaiter();
        }
    }
}