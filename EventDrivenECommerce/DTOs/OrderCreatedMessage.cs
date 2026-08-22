namespace EventDrivenECommerce.DTOs
{
    public class OrderCreatedMessage
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
