using AutoMapper;
using Progress = CardsConsumers.Progress;
using Todo = CardsConsumers.Progress;
using CardsManagerLib.Models.Data.Dtos;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CardsConsumers.RabbitMq
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
                        //READ QUEUE AND DESRRIALIZE A BYTE
                        var body = ea.Body.ToArray();
                        ReadCardDto cardDto = System.Text.Json.JsonSerializer.Deserialize<ReadCardDto>(body);
                        
                        //SEND CARD TO PROGRESS AND DELETE IN TODO
                        Progress.Connection cProgress = new Progress.Connection();
                        ConvertCard(ref cardDto);
                        if (!cProgress.Insert(cardDto))
                        {
                            channel.BasicNack(ea.DeliveryTag, false, true);
                        }
                        else
                        {
                            Todo.Connection cTodo = new Todo.Connection();
                            cTodo.Delete(cardDto.Id);
                            Console.WriteLine($"<==={cardDto.title} Received in progress! ");
                        }
                    };

                    channel.BasicConsume(queue: "todo-manager", autoAck: true, consumer: consumer);
                }

            }
        }

        public void ConvertCard(ref ReadCardDto card)
        {
            if(card.Priority.ToString().ToLower() == "alto")
            {
                card.Priority = "3";
            }else if(card.Priority.ToString().ToLower() == "medio")
            {
                card.Priority = "2";
            }
            else
            {
                card.Priority = "1";
            }
        }
    }
}