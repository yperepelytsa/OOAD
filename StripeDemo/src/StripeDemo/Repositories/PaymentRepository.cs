using StripeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Repositories
{
    public class PaymentRepository:IPaymentRepository
    {
        ApplicationDbContext _context;
        public PaymentRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public Payment addPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return payment;
        }
    }
}
