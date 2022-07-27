using CadsManagerLib.Models;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using todo_manager.Models.Entitie;

namespace todo_manager.RabbitMq
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

        public void PublicarElevateCard(Card card)
        {
            string teste = _configuration["RabbitMqHost"];
            
                var factory = new ConnectionFactory()
                {
                    HostName = _configuration["RabbitMqHost"]
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "todo-manager", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var serialize = JsonSerializer.Serialize(card);
                    var body = Encoding.UTF8.GetBytes(serialize);

                    channel.BasicPublish(exchange: "", routingKey: "todo-manager", basicProperties: null, body: body);

                    Console.WriteLine("Publish card");
                }
                Thread.Sleep(500);
            
            
        }

        /*
        public RabbitMqClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 15672,
                UserName = "root",
                Password = "sinqia123"
            }.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "Ex-todo-manager", type: ExchangeType.Fanout);
        }

        public void PublicarElevateCard(Card card)
        {
            
            string requisisao = JsonSerializer.Serialize(card);
            
            var body = Encoding.UTF8.GetBytes(requisisao);

            
            _channel.BasicPublish(
                exchange: "Ex-todo-manager",
                routingKey: "",
                basicProperties: null,
                body: body
                );

            Console.WriteLine("Send card to progress");
        }*/

    }
}
