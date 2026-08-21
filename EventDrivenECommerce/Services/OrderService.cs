using EventDrivenECommerce.AppDBContext;
using EventDrivenECommerce.DTOs;
using EventDrivenECommerce.Interfaces;
using EventDrivenECommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace EventDrivenECommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly db_context _context;

        public OrderService(db_context context)
        {
            _context = context;
        }

        public async Task<Orders> CreateOrderAsync(CreateOrderRequest request)
        {

            var order = new Orders
            {
                CustomerId = request.CustomerId,
                ProductName = request.ProductName,
                Quantity = request.Quantity,
                Price = request.Price,
                Status = "Created",
                CreatedAt = DateTime.UtcNow
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Orders> GetOrderList()
        {
            var data = await _context.Orders.FirstOrDefaultAsync();
            if(data == null){
                return null;
            }
            return data;
            
        }
    }
}
