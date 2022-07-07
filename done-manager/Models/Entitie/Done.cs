using CadsManagerLib.Models;
using CardsManagerLib.Enums;

namespace done_manager.Models.Entitie
{
    public class Done : Card
    {
        public string namePrority123(Priority priority)
        {
            return priority switch
            {
                Priority.BAIXO => "Baixo",
                Priority.MEDIO => "Medio",
                Priority.ALTO => "Alto",
                _ => "Inválido",
            };
        }
    }
}
