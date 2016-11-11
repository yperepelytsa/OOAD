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
        private readonly IOrderService _orderService;
        public OrderApiController(UserManager<ApplicationUser> userManager, IOrderService orderService)
        {
            _userManager = userManager;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> ExecuteOrder([FromBody]OrderDTO order)
        {
            var created = _orderService.executeOrder(order, HttpContext.User.Identity.Name, _userManager.FindByNameAsync(HttpContext.User.Identity.Name).GetAwaiter().GetResult().StripeClientId);
            //created at route
            return new NoContentResult();
        }




    }
}
