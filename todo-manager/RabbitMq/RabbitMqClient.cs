using CadsManagerLib.Models;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
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
            _connection = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = Int32.Parse(_configuration["RabbitMqPort"])
            }.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
        }

        public void PublicarElevateCard(Card card)
        {
            //serializar msg
            string requisisao = JsonSerializer.Serialize(card);
            //converter em bytes
            var body = Encoding.UTF8.GetBytes(requisisao);

            //corpo da mensagem sera criado atraves do canal de conexão
            _channel.BasicPublish(
                exchange: "trigger",
                routingKey: "",
                basicProperties: null,
                body: body
                );
        }
    }
}
