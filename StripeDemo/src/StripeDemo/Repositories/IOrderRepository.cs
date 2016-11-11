using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StripeDemo.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StripeDemo.Repositories
{
    public interface IOrderRepository 
    {
        Order addOrder(Order o);
        void SetExecuted(Order order);
        bool CheckOrder(Order order);
    }
}
