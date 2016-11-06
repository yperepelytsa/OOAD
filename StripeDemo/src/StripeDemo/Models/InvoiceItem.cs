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
        public string Price { get; set; }
        public string Number { get; set; }

        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }

        
    }
}
