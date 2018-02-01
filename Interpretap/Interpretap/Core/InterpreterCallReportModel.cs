using Interpretap.Interfaces;
using Interpretap.Models;
using Interpretap.Services;
using System.Threading.Tasks;

namespace Interpretap.Core
{
    public class InterpreterCallReportModel : ICallReportModel
    {
        public async Task<ICallReportResponce> FetchReport(string dateFrom, string dateTo)
        {
            var request = new CallReportRequestModel()
            {
                MinDay = dateFrom,
                MaxDay = dateTo
            };
            var service = new InterpreterService();
            var responce = await service.FetchMonthReport(request);
            return responce;
        }
    }
}
