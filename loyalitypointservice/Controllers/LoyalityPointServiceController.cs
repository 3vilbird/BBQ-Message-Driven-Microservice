using loyalitypointservice.Services;
using Microsoft.AspNetCore.Mvc;


namespace loyalitypointservice.Controllers
{

    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class LoyalityPointServiceController : ControllerBase
    {
        private readonly ILoyalityPointService _loyalityPointService;

        public LoyalityPointServiceController(ILoyalityPointService loyalityPointService)
        {
            _loyalityPointService = loyalityPointService;
        }

        [HttpGet]
        public async Task<IActionResult> loyalityPoints()
        {
            //
            var response = await _loyalityPointService.LoyalityPoints();
            return Ok(response);
        }

    }
}