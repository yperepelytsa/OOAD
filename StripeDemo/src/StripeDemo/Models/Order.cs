using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string SubmitterUserName { get; set; }
        public DateTime SubmittedOn { get; set; }
        public bool Executed { get; set; }
        public List<OrderItem> Items { get; set; }

    }
}
