using CadsManagerLib.Models;
using System;
using todo_manager.Models.Entitie;

namespace todo_manager.RabbitMq
{
    public interface IRabbitMqClient
    {
        void PublicarElevateCard(Card card);
    }
}
