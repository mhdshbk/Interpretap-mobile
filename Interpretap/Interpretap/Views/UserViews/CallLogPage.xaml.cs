using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Interpretap.Views.UserViews
{
    public partial class CallLogPage : ContentPage
    {
        public CallLogPage()
        {
            InitializeComponent();
            ObservableCollection<MonthlyCallReport> employees = new ObservableCollection<MonthlyCallReport>
            {
                new MonthlyCallReport{ DateFromTo = "2017-07-01 to 2017-07-31", TotalCalls="1"},
                new MonthlyCallReport{ DateFromTo = "2017-06-01 to 2017-07-30", TotalCalls="12"}
            };

            listView.ItemsSource = employees;

            listView.ItemSelected += (sender, e) => {
                MonthlyCallReport selectedCallReport = ((ListView)sender).SelectedItem as MonthlyCallReport;
                DisplayAlert("Item Selected", selectedCallReport.DateFromTo, "Ok");
            };
        }

    }

    public class MonthlyCallReport
    {
        public String DateFromTo { get; set; }
        public String TotalCalls { get; set; }
    }
}
