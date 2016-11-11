using StripeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Repositories
{
    public interface IPaymentRepository
    {
        Payment addPayment(Payment p);
    }
}
