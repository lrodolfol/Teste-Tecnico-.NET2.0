using System.Collections.Generic;
using todo_manager.Models.Data.Dtos;
using todo_manager.Models.Entitie;

namespace todo_manager.Models.Interfaces
{
    public interface IContextCard
    {
        IEnumerable<ReadCardDto> GetCardsDto(string title = null);
        ReadCardDto GetCardDto(int id);
        Card PostCard(CreateCardDto cardDto);
        bool PutCard(int id, CreateCardDto cardDto);
        bool DeleteCard(int id);
        void SaveChanges();
    }
}
