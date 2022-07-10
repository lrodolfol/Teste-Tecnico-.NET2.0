using CardsManagerLib.Interfaces;
using progress_manager.Models.Data;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace progress_manager.RabbitMqClient
{
    public class RabbitMqConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly string _nomeFila;
        private readonly IConnection _connection;
        private IModel _channel;
        private readonly ContextCard _contextCard;

        public RabbitMqConsumer(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new ConnectionFactory
            {
                HostName = _configuration["RabbiMqHost"],
                Port = Int32.Parse(_configuration["RabbitMqPort"])
            }.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _nomeFila = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _nomeFila, exchange: "trigger", routingKey: "");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ModeleHandle, args) =>
            {
                var body = args.Body;
                var mensagem = Encoding.UTF8.GetString(body.ToArray());

                //_processaEvento.Processa(mensagem);
                _contextCard.ElevateCard(mensagem);
            };

            _channel.BasicConsume(queue: _nomeFila, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
