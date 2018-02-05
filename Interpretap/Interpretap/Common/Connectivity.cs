using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.Common
{
    public static class Connectivity
    {
        public static bool CheckConnection(bool silentMode = false)
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (!isConnected && !silentMode)
            {
                App.Current.MainPage.DisplayAlert("Warning", "Device is offline", "OK");
            }
            return isConnected;
        }
    }
}
