using EventDrivenECommerce.Common;
using EventDrivenECommerce.DTOs;
using EventDrivenECommerce.Model;

namespace EventDrivenECommerce.Interfaces
{
    public interface IOrderService
    {
        Task<Orders> GetOrderList();
        Task<Orders> CreateOrderAsync(CreateOrderRequest request);
    }
}
