using System.Threading.Tasks;

namespace Interpretap.Interfaces
{
    public interface ICallReportModel
    {
        Task<ICallReportResponce> FetchReport(string dateFrom, string dateTo);
    }
}
