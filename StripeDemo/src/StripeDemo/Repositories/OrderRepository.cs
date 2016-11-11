using StripeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        ApplicationDbContext _context;
        public OrderRepository (ApplicationDbContext context)
        {
            this._context = context;
        }
        public Order addOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void SetExecuted(Order order)
        {
            order.Executed = true;
            foreach (var orderItem in order.Items)
            {
                var prod = _context.Products.Where(p => p.ProductId == orderItem.ProductId).FirstOrDefault();
                    prod.LeftInStock -= orderItem.Amount;
                _context.Entry(prod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        public bool CheckOrder(Order order)
        {
            bool valid = true;

            try {    
                       
            foreach (var orderItem in order.Items)
            {
                if (_context.Products.Where(p => p.ProductId == orderItem.ProductId).FirstOrDefault().LeftInStock < orderItem.Amount)
                    valid = false;
            }

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return valid;
        }
    }
}
