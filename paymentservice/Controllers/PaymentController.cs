using Microsoft.AspNetCore.Mvc;
using paymentservice.Services;
using ShredModels;

namespace paymentservice.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentservice;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentservice = paymentService;
        }


        /// <summary>
        /// creating new Payment 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Payment([FromBody] PaymentStatus payment) // post will have body
        {
            ResponseMessage response = await _paymentservice.ProcessPayment(payment);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            return Ok();
        }

    }
}