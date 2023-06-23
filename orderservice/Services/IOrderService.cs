using ShredModels;

namespace orderservice.Services
{
    public interface IOrderService
    {
        public Task<List<PaymentStatus>> Orders();
        public Task<ResponseMessage> Orders(PaymentStatus status);
        public Task<PaymentStatus> OpenOrder();
    }
}