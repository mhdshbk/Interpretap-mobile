using Interpretap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.ViewModels
{
    public class CallInfoViewModel : BaseViewModel
    {
        FifteenCallModel _callModel;

        public int InfoId => _callModel.CallInfoId;
        public string ReferenceId => _callModel.CallRefId;
        public string CreatedDate => _callModel.CreatedDate;
        public string StartDate => _callModel.StartCallDate;
        public string EndDate => _callModel.EndCallDate;
        public string Duration => _callModel.CallDuration;

        public CallInfoViewModel(FifteenCallModel call)
        {
            _callModel = call;
        }
    }
}
