using StripeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Repositories
{
    public class ProductRepository:IProductRepository
    {
        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int id){
            Console.WriteLine("products" + _context.Products.Count());
            return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }
       
    }
}
