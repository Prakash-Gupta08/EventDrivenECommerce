using EventDrivenECommerce.AppDBContext;
using EventDrivenECommerce.Common;
using EventDrivenECommerce.DTOs;
using EventDrivenECommerce.Interfaces;
using EventDrivenECommerce.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace EventDrivenECommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly db_context _context;
        protected ApiResponse _response;
        public OrderService(db_context context)
        {
            _context = context;
            _response = new();
        }

        public async Task<Orders> CreateOrderAsync(CreateOrderRequest request)
        {
            var data = await _context.Orders.FirstOrDefaultAsync(s => s.Id == request.CustomerId);
            if(data == null)
            {
                return null;
            }

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
