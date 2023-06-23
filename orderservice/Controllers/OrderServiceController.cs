using Microsoft.AspNetCore.Mvc;
using orderservice.Services;
using ShredModels;

namespace orderservice.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class OrderServiceController : ControllerBase
    {

        private readonly IOrderService _orderservice;

        public OrderServiceController(IOrderService orderService)
        {
            _orderservice = orderService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Order()
        {
            List<PaymentStatus> lstResponse = await _orderservice.Orders();
            return Ok(lstResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> OpenOrder()
        {
            PaymentStatus _PaymentStatus = await _orderservice.OpenOrder();
            return Ok(_PaymentStatus);
        }

    }
}