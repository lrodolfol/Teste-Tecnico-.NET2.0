using AutoMapper;
using CadsManagerLib.Models;
using CardsManagerLib.Interfaces;
using CardsManagerLib.Models.Data.Dtos;
using progress_manager.Models.Data;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace progress_manager.RabbitMqClient
{
    public class RabbitMqConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly string _nomeFila;
        private readonly IConnection _connection;
        private IModel _channel;
        private readonly IContextCard _contextCard;
        private readonly IMapper _mapper;

        public RabbitMqConsumer(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public void Consumir()
        {
            while(true)
            {
                var factory = new ConnectionFactory() { HostName = _configuration["RabbitMqHost"] };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "todo-manager", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        try
                        {
                            var body = ea.Body.ToArray();
                            CreateCardDto card = System.Text.Json.JsonSerializer.Deserialize<CreateCardDto>(body);

                            //_contextCard.PostCard(card);
                            Console.WriteLine("Consumido");

                            channel.BasicAck(ea.DeliveryTag, false);
                        }
                        catch (Exception ex)
                        {
                            channel.BasicNack(ea.DeliveryTag, false, true);
                        }
                    };

                    channel.BasicConsume(queue: "todo-manager", autoAck: false, consumer: consumer);
                }
                Thread.Sleep(200);
            }
            

        }


        /*
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

                _contextCard.ElevateCard(mensagem);
            };

            _channel.BasicConsume(queue: _nomeFila, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
        */
    }
}
