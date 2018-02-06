using Plugin.Connectivity;

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

        public static void OnTimeout()
        {
            App.Current.MainPage.DisplayAlert("Error", "Connection timeout", "OK");
        }
    }
}
