using StripeDemo.Models;
using StripeDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Factories
{
    public class InvoiceFactory
    {
        public IProductRepository _productRepo;
        public InvoiceFactory(IProductRepository repo)
        {
            this._productRepo = repo;
        }
        public Invoice Create(Order order)
        {
            Invoice invoice = new Invoice(){
                SubmittedOn = order.SubmittedOn,
                SubmitterUserName = order.SubmitterUserName,
                Items = new List<InvoiceItem>()
            };
            foreach (var orderitem in order.Items)
            {
                var product = _productRepo.GetById(orderitem.ProductId);
                invoice.Items.Add(new InvoiceItem()
                {                   
                    Number = orderitem.Amount,                    
                    Price = product.Price,
                    ProductName = product.Name
                });
                invoice.TotalItems += orderitem.Amount;
                invoice.TotalSum += orderitem.Amount * product.Price;
            }
         

            return invoice;
        }
    }
}
