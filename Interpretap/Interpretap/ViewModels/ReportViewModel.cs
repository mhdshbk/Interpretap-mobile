using Interpretap.Common;
using Interpretap.Models;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interpretap.Common.Constants;

namespace Interpretap.ViewModels
{
    class ReportViewModel : BaseViewModel
    {
        private string _totalCallSeconds;
        public string TotalCallSeconds
        {
            get { return _totalCallSeconds; }
            set { _totalCallSeconds = value + " seconds"; INotifyPropertyChanged(); }
        }

        private string _totalPausedSeconds;
        public string TotalPausedSeconds
        {
            get { return _totalPausedSeconds; }
            set { _totalPausedSeconds = value + " seconds"; INotifyPropertyChanged(); }
        }

        private string _businessFee;
        public string BusinessFee
        {
            get { return _businessFee; }
            set { _businessFee = value; INotifyPropertyChanged(); }
        }

        private string _totalBill;
        public string TotalBill
        {
            get { return _totalBill; }
            set { _totalBill = "$" + value; INotifyPropertyChanged(); }
        }


        public async Task LoadData(String minDay, String maxDay, UserTypes userType)
        {
            var callLogRequestModel = new CallReportRequestModel();
            callLogRequestModel.MinDay = minDay;
            callLogRequestModel.MaxDay = maxDay;
            FetchABReportResponse response = null;
            switch (userType)
            {
                case UserTypes.Business:
                    BusinessService businessService = new BusinessService();
                    callLogRequestModel.ClientBusinessId = LocalStorage.LoginResponseLS.UserInfo.ClientInfo.Businesses.Last().ClientBusinessId;
                    response = await businessService.FetchBusinessReport(callLogRequestModel);
                    break;

                case UserTypes.Agency:
                    AgencyService agencyService = new AgencyService();
                    callLogRequestModel.AgencyId = LocalStorage.LoginResponseLS.UserInfo.InterpreterInfo.Agencies.Last().InterpreterBusinessId;
                    response = await agencyService.FetchAgencyReport(callLogRequestModel);
                    break;
            }

            var reportInfo = userType == UserTypes.Agency ? response.AgencyReport : response.BusinessReport;
            var fee = userType == UserTypes.Agency ? reportInfo.FeeInfos.First().FeePerMinute : reportInfo.BillInfo.First().FeePerMinute;
            TotalCallSeconds = reportInfo.Report.TotalCall.ToString();
            TotalPausedSeconds = reportInfo.Report.TotalPause.ToString();
            BusinessFee = fee.ToString();
            TotalBill = (reportInfo.Report.TotalCall * fee).ToString();
        }
    }
}
