using loyalitypointservice.Services;
using MassTransit;
using ShredModels;

namespace orderservice.MessageConsumer
{
    public class MessageConsumer : IConsumer<PaymentStatus>
    {


        private readonly ILoyalityPointService _loyalityservice;

        public MessageConsumer(ILoyalityPointService loyalityservice)
        {
            _loyalityservice = loyalityservice;
        }
        public async Task Consume(ConsumeContext<PaymentStatus> context)
        {
            await _loyalityservice.AddLoyalityPoint(context.Message);
        }
    }
}