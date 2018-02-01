using Interpretap.Models.RespondModels.InnerTypes;

namespace Interpretap.Interfaces
{
    public interface ICallReportResponce
    {
        bool Status { get; set; }
        string Message { get; set; }
        CallReport Report { get; set; }
    }
}
