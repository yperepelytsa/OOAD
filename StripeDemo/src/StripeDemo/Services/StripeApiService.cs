using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Services
{
    public class StripeApiService:IStripeApiService
    {
        public StripeApiService() { }
        public Tuple<string,bool> executeCharge(int orderId, int TotalSum, string StripeClientId) {
           
                    var myCharge = new StripeChargeCreateOptions
                    {
                        Amount = TotalSum,
                        Currency = "usd",
                        Description = "Charge for order #"+orderId,
                        CustomerId = StripeClientId
                    };

                    var chargeService = new StripeChargeService();
                    var stripeCharge = chargeService.Create(myCharge);

            return Tuple.Create(stripeCharge.Id, stripeCharge.Paid);
        }

    }
}
