using Interpretap.Common;
using Interpretap.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Interpretap
{
    public class MainPageFactory
    {
        public TabbedPage CreateMainPageForClient()
        {
            var page = new TabbedPage
            {
                Children =
                {
                    new Views.UserViews.RequestPage(),
                    new Views.UserViews.CallLogPage()
                }
            };

            if (LocalStorage.LoginResponseLS.UserInfo.IsManager)
                page.Children.Add(new Views.UserViews.BusinessesPage());

            page.Children.Add(new ProfilePage());
            page.CurrentPage = null;
            NavigationPage.SetHasNavigationBar(page, false);
            return page;
        }

        public TabbedPage CreateMainPageForInterpreter()
        {
            var page = new TabbedPage
            {
                Children =
                {
                    new Views.InterpreterViews.CallQueuePage(),
                    new Views.InterpreterViews.CallLogPage()
                }
            };

            if (LocalStorage.LoginResponseLS.UserInfo.IsManager)
                page.Children.Add(new Views.InterpreterViews.AgenciesPage());

            page.Children.Add(new ProfilePage());
            page.CurrentPage = null;
            NavigationPage.SetHasNavigationBar(page, false);
            return page;
        }
    }
}
