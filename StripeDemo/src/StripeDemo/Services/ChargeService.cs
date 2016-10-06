using StripeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Services
{
    public class ChargeService:IChargeService
    {
        public async Invoice executeOrder(Order o) {
            //create charge for stripe from order, complete it
            //create invoice from return of stripe call
        }
    }

}
