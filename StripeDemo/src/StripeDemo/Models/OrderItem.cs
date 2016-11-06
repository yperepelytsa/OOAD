namespace StripeDemo.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set;}
        public int Amount { get; set; }
        public int ProductId { get; set; }
    }
}