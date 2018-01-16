using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Services;
using Interpretap.Views.InterpreterViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.ViewModels
{
    public class AgenciesViewModel : BaseViewModel
    {
        public List<AssosiateAgencies> Agencies => LocalStorage.LoginResponseLS.UserInfo.InterpreterInfo.Agencies;

        public void ShowMounthlyCallReportForAgency(AssosiateAgencies agency)
        {
            App.Current.MainPage.Navigation.PushAsync(new AgencyCallsPage(agency));
        }
    }
}
