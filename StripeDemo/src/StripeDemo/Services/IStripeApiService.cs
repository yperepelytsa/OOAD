using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Services
{
    public interface IStripeApiService
    {
        Tuple<string, bool> executeCharge(int orderId, int TotalSum, string StripeClientId);
    }
}
