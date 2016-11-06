using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StripeDemo.Models;
namespace StripeDemo.Services
{
    public interface IChargeService
    {
        Task<Invoice> executeOrder(OrderDTO order, string stripeClientId);
    }
}
