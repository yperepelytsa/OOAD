using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Models
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }

        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }

        
    }
}
