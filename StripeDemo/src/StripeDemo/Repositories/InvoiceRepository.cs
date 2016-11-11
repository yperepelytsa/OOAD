using StripeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Repositories
{
    public class InvoiceRepository: IInvoiceRepository
    {
        ApplicationDbContext _context;
        public InvoiceRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public Invoice addInvoice(Invoice invoice) {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            return invoice;
        }
    }
}
