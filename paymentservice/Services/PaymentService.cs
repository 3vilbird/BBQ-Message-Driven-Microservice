using MassTransit;
using ShredModels;

namespace paymentservice.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public PaymentService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task<ResponseMessage> ProcessPayment(PaymentStatus payment)
        {

            //TODO: pulbish the message here;
            await _publishEndpoint.Publish<PaymentStatus>(payment);
            return new ResponseMessage
            {
                strResponseMessage = "payment  response message bulished",
                responseStatus = "200"
            };
        }
    }
}