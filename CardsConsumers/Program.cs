// See https://aka.ms/new-console-template for more information
using CardsConsumers;

Console.WriteLine("===App Running===");
Console.WriteLine("-");

ConsumerQueueProgress consumerProgress = new ConsumerQueueProgress();

while (true)
{
    consumerProgress.Consume("localhost");
}