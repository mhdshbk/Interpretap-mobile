using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.Common
{
    public static class Dialogs
    {
        public static async Task<int> SelectInterpreterBusinessActionSheetAsync(string title, string cancel)
        {
            List<string> options = new List<string>();
            foreach (var business in LocalStorage.LoginResponseLS.UserInfo.InterpreterInfo.Agencies)
            {
                options.Add(business.BusinessInfo.BusinessName);
            }
            var selectedBusinessName = await App.Current.MainPage.DisplayActionSheet(title, cancel, "", options.ToArray());
            var canceled = selectedBusinessName == cancel;
            if (selectedBusinessName != null && !canceled)
            {
                var selectedBusinessId = LocalStorage.LoginResponseLS.UserInfo.InterpreterInfo.Agencies.FirstOrDefault(i => i.BusinessInfo.BusinessName.Equals(selectedBusinessName)).InterpreterBusinessId;
                return selectedBusinessId;
            }
            else
            {
                return 0;
            }
        }
    }
}
