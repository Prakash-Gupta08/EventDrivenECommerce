using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventDrivenECommerce.RabbitMQ
{

    public class RabbitMqConsumer : BackgroundService
    {
        private IConnection? _connection;
        private IChannel? _channel;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            _connection = await factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            await _channel.QueueDeclareAsync(
                queue: "email_queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += async (sender, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();

                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Received message: {message}");

                await _channel.BasicAckAsync(
                    eventArgs.DeliveryTag,
                    multiple: false
                );
            };

            await _channel.BasicConsumeAsync(
                queue: "email_queue",
                autoAck: false,
                consumer: consumer
            );

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_channel != null)
                await _channel.CloseAsync();

            if (_connection != null)
                await _connection.CloseAsync();

            await base.StopAsync(cancellationToken);
        }
    }
}
