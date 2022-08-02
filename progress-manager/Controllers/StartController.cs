using CardsManagerLib.Interfaces;
using Microsoft.AspNetCore.Mvc;
using progress_manager.RabbitMqClient;

namespace progress_manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            return Ok();
        }
    }
}
