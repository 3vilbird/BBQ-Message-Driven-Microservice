using MassTransit;
using Newtonsoft.Json;
using orderservice.Services;
using ShredModels;

namespace orderservice.MessageConsumer
{
    public class MessageConsumer : IConsumer<PaymentStatus>
    {


        private readonly IOrderService _orderservice;

        public MessageConsumer(IOrderService orderService)
        {
            _orderservice = orderService;
        }
        public async Task Consume(ConsumeContext<PaymentStatus> context)
        {
            await _orderservice.Orders(context.Message);
        }
    }
}