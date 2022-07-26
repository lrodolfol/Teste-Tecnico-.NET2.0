using AutoMapper;
using CardsManagerLib.Models.Data.Dtos;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsConsumers
{
    public class ConsumerQueueProgress
    {
        private readonly IConfiguration _configuration;
        private readonly string _nomeFila;
        private readonly IConnection _connection;
        private IModel _channel;
        private readonly IMapper _mapper;

        public void Consume(string hostName)
        {
            var factory = new ConnectionFactory() { HostName = hostName };
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

                        Console.WriteLine("Consumido");

                        //ENVIAR PARA API PROGRESS

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        channel.BasicNack(ea.DeliveryTag, false, true);
                    }
                };
                channel.BasicConsume(queue: "todo-manager", autoAck: false, consumer: consumer);
            }
        }
    }
}