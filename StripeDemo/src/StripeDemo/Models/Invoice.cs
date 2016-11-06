using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int TotalItems { get; set; }
        public int TotalSum { get; set; }
        public string SubmitterUserName { get; set; }
        public DateTime SubmittedOn { get; set; }

        public List<InvoiceItem> Items { get; set; }
    }
}
