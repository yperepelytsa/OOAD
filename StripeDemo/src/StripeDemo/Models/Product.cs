using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Vendor { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int LeftInStock { get; set; }
    }
}
