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

        public void Consume()
        {   
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "todo-manager", durable: false, exclusive: false, autoDelete: false, arguments: null);
                
                while (true)
                {
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        CreateCardDto cardDto = System.Text.Json.JsonSerializer.Deserialize<CreateCardDto>(body);

                        Connection c = new Connection();
                        if(! c.Insert(cardDto))
                        {
                            channel.BasicNack(ea.DeliveryTag, false, true);
                        }
                        else
                        {
                            Console.WriteLine($"<==={cardDto.title} Received in progress! ");
                        }


                    };

                    channel.BasicConsume(queue: "todo-manager", autoAck: true, consumer: consumer);
                }

            }
        }
    }
}