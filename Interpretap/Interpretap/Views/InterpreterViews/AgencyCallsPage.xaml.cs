﻿using Interpretap.Models;
using Interpretap.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Interpretap.Common.Constants;

namespace Interpretap.Views.InterpreterViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgencyCallsPage : ContentPage
    {
        private CallLogViewModel _viewModel { get; set; }

        public AgencyCallsPage(AssosiateAgencies agency = null)
        {
            InitializeComponent();
            
            _viewModel = new CallLogViewModel() { Agency = agency };
            BindingContext = _viewModel;

            listView.ItemsSource = _viewModel.CallLogs;

            listView.ItemSelected += (sender, e) =>
            {
                if (((ListView)sender).SelectedItem == null)
                    return;

                MonthlyCallReportModel selectedCallReport = ((ListView)sender).SelectedItem as MonthlyCallReportModel;
                Navigation.PushAsync(new CallLogDetailsAB(selectedCallReport, UserTypes.Agency));
                ((ListView)sender).SelectedItem = null;
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_viewModel.CallLogs.Count == 0)
                _viewModel.LoadData(DateTime.Now.ToString("yyyy-MM-dd"), UserTypes.Agency).GetAwaiter();
        }
    }
}