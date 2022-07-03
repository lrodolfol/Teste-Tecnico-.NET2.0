using Microsoft.AspNetCore.Mvc;
using todo_manager.Models.Data.Dtos;

namespace todo_manager.Models.Interfaces
{
    public interface ICardController
    {
        public ActionResult<ReadCardDto> GetCard([FromQuery] string title);
        public IActionResult GetCard(int id);
        public IActionResult PutCard(int id, CreateCardDto card);
        public IActionResult PostCard(CreateCardDto card);
        public IActionResult DeleteCard(int id);
    }
}
