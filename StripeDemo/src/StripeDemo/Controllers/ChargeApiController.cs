using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StripeDemo.Models;
namespace StripeDemo.Controllers
{
    public class ChargeApiController : Controller
    {
        //needed repos
        //needed services
        [HttpPost]
        public async Task<IActionResult> ExecuteOrder(Order o)
        {
            //create order
            //use injected service to pass the order to stripe, get invoice and put it into db
            //Invoice i=ChargeService.executeOrder(o);
            //repo.addInvoice(i);
            return new NoContentResult();
        }
    }
}
