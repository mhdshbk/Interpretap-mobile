using Interpretap.Common;
using Interpretap.Models.RespondModels;
using Xamarin.Forms;

namespace Interpretap.Services
{
    public class ResponceContentStatusChecker
    {
        public void Check(object content)
        {
            if (content is BaseRespond)
            {
                CheckBaseRespond(content as BaseRespond);
            }
        }

        private void CheckBaseRespond(BaseRespond baseRespond)
        {
            if (!baseRespond.Status)
            {
                if (baseRespond.Message == Constants.Strings.SessionKeyInvalidMessage)
                {
                    MessagingCenter.Send(this, Constants.Strings.SessionFailed);
                }
            }
        }
    }
}
