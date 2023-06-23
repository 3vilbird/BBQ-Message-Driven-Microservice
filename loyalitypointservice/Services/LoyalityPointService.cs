using ShredModels;
namespace loyalitypointservice.Services
{
    public class LoyalityPointService : ILoyalityPointService
    {
        private List<LoyalityPoints> _loyalityList;

        public LoyalityPointService()
        {
            //
            _loyalityList = new List<LoyalityPoints>();
        }
        public async Task<ResponseMessage> AddLoyalityPoint(PaymentStatus paymentStatus)
        {
            _loyalityList.Add(new LoyalityPoints { iPoint = new Random().Next(52), uUserId = paymentStatus.uUserId, uOrderId = paymentStatus.uOrderId });
            return new ResponseMessage { strResponseMessage = "Loyality points credited", responseStatus = "200" };

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<LoyalityPoints>> LoyalityPoints()
        {
            return _loyalityList;

        }
    }
}