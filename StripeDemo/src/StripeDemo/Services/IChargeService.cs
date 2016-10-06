using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StripeDemo.Models;
namespace StripeDemo.Services
{
    interface IChargeService
    {
         Invoice executeOrder(Order o);
    }
}
