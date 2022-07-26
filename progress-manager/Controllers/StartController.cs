using Microsoft.AspNetCore.Mvc;
using progress_manager.RabbitMqClient;

namespace progress_manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StartController : ControllerBase
    {
        private readonly RabbitMqConsumer _consumer;
        public StartController(RabbitMqConsumer consumer)
        {
            _consumer = consumer;
        }
        [HttpGet]
        public ActionResult GetCard()
        {
            _consumer.Consumir();
            return Ok();
        }
    }
}
