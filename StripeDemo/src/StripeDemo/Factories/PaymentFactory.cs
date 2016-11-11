using StripeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Factories
{
    public class PaymentFactory
    {
        public Payment Create(string ChargeToken, int OrderId)
        {
            Payment payment = new Payment()
            {
              ChargeToken=ChargeToken,
              OrderId=OrderId
            };
            return payment;
        }
    }
}
