using ShredModels;

namespace paymentservice.Services
{
    public interface IPaymentService
    {
        public Task<ResponseMessage> ProcessPayment(PaymentStatus payment);
    }
}