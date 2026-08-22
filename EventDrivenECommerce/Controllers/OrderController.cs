using EventDrivenECommerce.DTOs;
using EventDrivenECommerce.Interfaces;
using EventDrivenECommerce.Model;
using EventDrivenECommerce.RabbitMQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventDrivenECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var order = await _orderService.CreateOrderAsync(request);

            return Ok(order);
        }

        [HttpGet("GetOrderList")]
        public async Task<ActionResult> GetOrderList()
        {
            var data = await _orderService.GetOrderList();
            if(data == null)
            {
                return null;
            }
            return Ok(data);
        }

        //[HttpPost("test-rabbitmq")]
        //public async Task<IActionResult> TestRabbitMq()
        //{
        //    var producer = new RabbitMqProducer();

        //    await producer.SendMessageAsync("Hello RabbitMQ");

        //    return Ok("Message sent to RabbitMQ");
        //}
    }
}
