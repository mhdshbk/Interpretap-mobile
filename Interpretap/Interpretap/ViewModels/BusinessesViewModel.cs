using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Services;
using Interpretap.Views.InterpreterViews;
using Interpretap.Views.UserViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.ViewModels
{
    public class BusinessesViewModel : BaseViewModel
    {
        public List<AssosiateBusiness> Businesses => LocalStorage.LoginResponseLS.UserInfo.ClientInfo.Businesses;

        public void ShowMounthlyCallReportForBusiness(AssosiateBusiness business)
        {
            App.Current.MainPage.Navigation.PushAsync(new BusinessCallsPage(business));
        }
    }
}
