using Stripe;
using StripeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Services
{
    public class ChargeService : IChargeService
    {
        public async Task<Invoice> executeOrder(OrderDTO order, string stripeClientId) {


             await System.Threading.Tasks.Task.Run(() =>
            {
                var myCharge = new StripeChargeCreateOptions
                {
                    Amount = 50,
                    Currency = "usd",
                    Description = "Charge for property sign and postage2",
                    CustomerId = stripeClientId
                };

                var chargeService = new StripeChargeService();
                var stripeCharge = chargeService.Create(myCharge);

                return stripeCharge.Id;
            });
            return null;
            //create charge for stripe from order, complete it
            //create invoice from return of stripe call
        }

    }
}
