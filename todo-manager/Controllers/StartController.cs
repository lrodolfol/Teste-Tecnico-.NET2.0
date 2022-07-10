
using CardsManagerLib.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace todo_manager.Controllers
{
    [ApiController]
    [Route("api/todo/[controller]")]
    public class StartController : ControllerBase
    {
        private IContextCard _contextCard;
        public StartController(IContextCard contextCard)
        {
            _contextCard = contextCard;
        }
        [HttpGet("{id}")]
        public IActionResult StartTodo(int id)
        {
            _contextCard.ElevateCard(id);
            //chamar metodo o progress-manager e realizar novo post
            

            return Ok();
        }
    }
}
