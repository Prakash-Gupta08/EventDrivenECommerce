using EventDrivenECommerce.DTOs;

namespace EventDrivenECommerce.Interfaces
{
    public interface IRabbitMqProducer
    {
        Task SendOrderCreatedAsync(OrderCreatedMessage message);
    }
}
