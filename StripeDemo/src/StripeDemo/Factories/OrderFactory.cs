using StripeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Factories
{
    public class OrderFactory
    {
        public OrderFactory() { }
        public  Order Create(OrderDTO data, string UserName)
        {
            Order order = new Order(){
                SubmittedOn = DateTime.Now,
                SubmitterUserName = UserName,
                Items = data.Items
            };
            return order;
        }
    }
}
