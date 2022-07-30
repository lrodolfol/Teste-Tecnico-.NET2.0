using CardsManagerLib.Models.Data.Dtos;

namespace todo_manager.RabbitMq
{
    public interface IRabbitMqClient
    {
        void PublicarElevateCard(CreateCardDto card);
    }
}
