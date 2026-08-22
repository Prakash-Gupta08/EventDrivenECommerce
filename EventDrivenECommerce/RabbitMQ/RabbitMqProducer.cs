using EventDrivenECommerce.DTOs;
using EventDrivenECommerce.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace EventDrivenECommerce.RabbitMQ
{
    public class RabbitMqProducer : IRabbitMqProducer
    {
        //public async Task SendMessageAsync(string message)
        //{
        //    var factory = new ConnectionFactory
        //    {
        //        HostName = "localhost",
        //        Port = 5672,
        //        UserName = "guest",
        //        Password = "guest"
        //    };

        //    await using var connection = await factory.CreateConnectionAsync();
        //    await using var channel = await connection.CreateChannelAsync();

        //    await channel.QueueDeclareAsync(
        //        queue: "email_queue",
        //        durable: true,
        //        exclusive: false,
        //        autoDelete: false,
        //        arguments: null
        //    );

        //    var body = Encoding.UTF8.GetBytes(message);

        //    await channel.BasicPublishAsync(
        //        exchange: "",
        //        routingKey: "email_queue",
        //        body: body
        //    );
        //}

        public async Task SendOrderCreatedAsync(OrderCreatedMessage message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            await using var connection = await factory.CreateConnectionAsync();

            await using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: "email_queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var json = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: "email_queue",
                body: body
            );

        }
    }
}
