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
                    new Views.UserViews.RequestPage()
                    {
                        Icon = "callrequests"
                    },
                    new Views.UserViews.CallLogPage()
                    {
                        Icon = "calls"
                    }
                }
            };

            if (LocalStorage.LoginResponseLS.UserInfo.IsManager)
                page.Children.Add(new Views.UserViews.BusinessesPage()
            {
                Icon = "business"
            });

            page.Children.Add(new ProfilePage()
            {
                Icon = "profile"
            });
            page.CurrentPage = null;
            page.Title = "Interpretap";
            NavigationPage.SetHasNavigationBar(page, true);
            NavigationPage.SetBackButtonTitle(page, "");
            return page;
        }

        public TabbedPage CreateMainPageForInterpreter()
        {
            var page = new TabbedPage
            {
                Children =
                {
                    new Views.InterpreterViews.CallQueuePage()
                    {
                        Icon="callqueue"
                    },
                    new Views.InterpreterViews.CallLogPage()
                    {
                        Icon="calllog"
                    }
                }
            };

            if (LocalStorage.LoginResponseLS.UserInfo.IsManager)
                page.Children.Add(new Views.InterpreterViews.AgenciesPage()
            {
                Icon="agency"
            });

            page.Children.Add(new ProfilePage()
            {
                Icon="profile"
            });
            page.CurrentPage = null;
            page.Title = "Interpretap";
            NavigationPage.SetHasNavigationBar(page, true);
            NavigationPage.SetBackButtonTitle(page, "");
            return page;
        }
    }
}
