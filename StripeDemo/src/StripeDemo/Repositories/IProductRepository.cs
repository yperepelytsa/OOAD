using StripeDemo.Models;
using System.Collections.Generic;

namespace StripeDemo.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetById(int id);
        
    }
}