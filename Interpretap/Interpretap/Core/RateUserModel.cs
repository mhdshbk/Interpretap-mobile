using Interpretap.Models;
using Interpretap.Models.RespondModels;
using Interpretap.Services;
using System.Threading.Tasks;

namespace Interpretap.Core
{
    public class RateUserModel
    {
        string _rateeUserId;
        string _callId;

        public RateUserModel(string rateeUserId, string callId)
        {
            _rateeUserId = rateeUserId;
            _callId = callId;
        }

        public async Task<BaseRespond> RateUserAsync(string ratingId)
        {
            var request = new RateUserRequestModel()
            {
                RateeUserId = _rateeUserId,
                CallId = _callId,
                RatingId = ratingId,
            };

            var service = new UserService();
            var responce = await service.RateUser(request);

            return responce;
        }
    }
}
