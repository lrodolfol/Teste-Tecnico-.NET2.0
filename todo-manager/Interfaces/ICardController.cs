using Microsoft.AspNetCore.Mvc;
using todo_manager.Models.Data.Dtos;
using todo_manager.Models.Entitie;

namespace todo_manager.Interfaces
{
    public interface ICardController
    {
        public IActionResult GetCard([FromQuery] string title);
        public IActionResult GetCard(int id);
        public IActionResult PutCard(int id, CreateCardDto card);
        public IActionResult PostCard(CreateCardDto card);
        public IActionResult DeleteCard(int id);

    }
}
