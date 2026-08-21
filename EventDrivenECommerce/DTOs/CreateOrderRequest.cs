namespace EventDrivenECommerce.DTOs
{
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
