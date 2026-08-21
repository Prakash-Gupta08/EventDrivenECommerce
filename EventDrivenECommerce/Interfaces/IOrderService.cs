using EventDrivenECommerce.DTOs;
using EventDrivenECommerce.Model;

namespace EventDrivenECommerce.Interfaces
{
    public interface IOrderService
    {
        Task<Orders> CreateOrderAsync(CreateOrderRequest request);
    }
}
