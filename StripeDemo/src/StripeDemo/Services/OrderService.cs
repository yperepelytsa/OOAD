using Stripe;
using StripeDemo.Factories;
using StripeDemo.Models;
using StripeDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripeDemo.Services
{
    public class OrderService : IOrderService
    {
        OrderFactory _orderFactory;
        InvoiceFactory _invoiceFactory;
        PaymentFactory _paymentFactory;
        IOrderRepository _orderRepo;
        IPaymentRepository _paymentRepo;
        IProductRepository _productRepo;
        IInvoiceRepository _invoiceRepo;
        IStripeApiService _stripeService;

        public OrderService(OrderFactory orderFactory,InvoiceFactory invoiceFactory, PaymentFactory paymentFactory, IOrderRepository orderRepo,
            IPaymentRepository paymentRepo, IProductRepository productRepo, IInvoiceRepository invoiceRepo, IStripeApiService stripeService)
        {
            this._orderFactory = orderFactory;
            this._invoiceFactory = invoiceFactory;
            this._paymentFactory = paymentFactory;
            this._orderRepo = orderRepo;
            this._paymentRepo = paymentRepo;
            this._productRepo = productRepo;
            this._invoiceRepo = invoiceRepo;
            this._stripeService = stripeService;
        }
        public Order executeOrder(OrderDTO orderdto, string UserName,string StripeClientId) {
            var order = _orderFactory.Create(orderdto, UserName);
            var invoice = _invoiceFactory.Create(order);
            if (!_orderRepo.CheckOrder(order))
            {
                return null;
            }
            order = _orderRepo.addOrder(order);
            invoice = _invoiceRepo.addInvoice(invoice);
            var succeded = _stripeService.executeCharge(order.OrderId, invoice.TotalSum, StripeClientId);
            Payment payment;
            if (succeded.Item2)
            {
                payment = _paymentFactory.Create(succeded.Item1, order.OrderId);
                _orderRepo.SetExecuted(order);
                _paymentRepo.addPayment(payment);
            }
            else
            {
                payment = _paymentFactory.Create(succeded.Item1, order.OrderId);
                _paymentRepo.addPayment(payment);
            }
          
            return order;
            //create charge for stripe from order, complete it
            //create invoice from return of stripe call
        }

    }
}
