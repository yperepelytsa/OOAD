using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StripeDemo.Models;
namespace StripeDemo.Services
{
    public interface IOrderService
    {
        Order executeOrder(OrderDTO order,string UserName, string stripeClientId);
    }
}
