using CardsManagerLib.Models.Data.Dtos;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace progress_manager.RabbitMq
{
    public class RabbitMqClient : IRabbitMqClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void PublicarElevateCard(ReadCardDto card)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMqHost"]
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "progress-manager", durable: false, exclusive: false, autoDelete: false, arguments: null);
                var serialize = JsonSerializer.Serialize(card);
                var body = Encoding.UTF8.GetBytes(serialize);

                channel.BasicPublish(exchange: "", routingKey: "progress-manager", basicProperties: null, body: body);

                Console.WriteLine($"===> {card.title} send to progress");
            }
        }
    }
}
