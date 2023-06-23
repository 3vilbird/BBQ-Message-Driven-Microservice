using ShredModels;

namespace loyalitypointservice.Services
{
    public interface ILoyalityPointService
    {
        public Task<List<LoyalityPoints>> LoyalityPoints();
        public Task<ResponseMessage> AddLoyalityPoint(PaymentStatus paymentStatus);

    }
}