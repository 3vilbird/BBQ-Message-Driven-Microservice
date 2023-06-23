using ShredModels;
using System;


namespace orderservice.Services
{
    public class OrderService : IOrderService
    {

        private List<PaymentStatus> _statusData;

        public OrderService()
        {
            _statusData = new List<PaymentStatus>();
        }

        public async Task<PaymentStatus> OpenOrder()
        {

            return new PaymentStatus
            {
                blnPaymentStatus = false,
                uOrderId = Guid.NewGuid().ToString(),
                uUserId = Guid.NewGuid().ToString()
            };
        }

        public async Task<ResponseMessage> Orders(PaymentStatus status)
        {
            _statusData.Add(status);
            return new ResponseMessage { responseStatus = "200", strResponseMessage = "orderClosed" };
        }

        public async Task<List<PaymentStatus>> Orders()
        {
            return _statusData;
        }

    }
}