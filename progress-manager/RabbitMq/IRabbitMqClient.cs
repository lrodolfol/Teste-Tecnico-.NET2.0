using CardsManagerLib.Models.Data.Dtos;

namespace progress_manager.RabbitMq
{
    public interface IRabbitMqClient
    {
        void PublicarElevateCard(ReadCardDto card);
    }
}
