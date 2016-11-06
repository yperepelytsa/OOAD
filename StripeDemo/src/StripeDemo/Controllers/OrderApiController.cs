using Stripe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using StripeDemo.Services;
using Microsoft.AspNetCore.Mvc;
using StripeDemo.Models;
using System.Threading.Tasks;

namespace StripeDemo.Controllers
{
    [Authorize]
    [Route("api/order")]
    public class OrderApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IChargeService _chargeService;
        public OrderApiController(UserManager<ApplicationUser> userManager, IChargeService chargeService)
        {
            _userManager = userManager;
            _chargeService = chargeService;
        }

        [HttpPost]
        public async Task<IActionResult> ExecuteOrder([FromBody]OrderDTO order)
        {
            var created = await _chargeService.executeOrder(order, _userManager.FindByNameAsync(HttpContext.User.Identity.Name).GetAwaiter().GetResult().StripeClientId);
            //created at route
            return new NoContentResult();
        }




    }
}
