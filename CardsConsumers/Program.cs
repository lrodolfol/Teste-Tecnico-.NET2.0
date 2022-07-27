// See https://aka.ms/new-console-template for more information
using CardsConsumers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("===App Running===");
Console.WriteLine("-");

while (true)
{
    ConsumerQueueProgress consumerProgress = new ConsumerQueueProgress();
    consumerProgress.Consume("localhost");
}