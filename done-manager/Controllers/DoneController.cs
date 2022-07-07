using AutoMapper;
using CadsManagerLib.Models;
using CardsManagerLib.Interfaces;
using CardsManagerLib.Models.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace done_manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoneController : ControllerBase
    {
        private IMapper _mapper;
        private IContextCard _contextCard;

        public DoneController(IMapper mapper, IContextCard contextCard)
        {
            _mapper = mapper;
            _contextCard = contextCard;
        }

        [HttpPost]
        public IActionResult PostCard([FromBody] CreateCardDto cardDto)
        {
            Card cardTodo = _contextCard.PostCard(cardDto);

            if (cardTodo == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetCard), new { id = cardTodo.Id }, cardTodo);

        }

        [HttpGet]
        public ActionResult<ReadCardDto> GetCard()
        {
            return Ok(_contextCard.GetCardsDto(""));
        }

        [HttpGet("{id}")]
        public IActionResult GetCard(int id)
        {
            ReadCardDto readCardTodo = _contextCard.GetCardDto(id);
            if (readCardTodo == null)
            {
                return NotFound();
            }

            return Ok(readCardTodo);
        }

        [HttpPut("{id}")]
        public IActionResult PutCard(int id, CreateCardDto cardDto)
        {
            return _contextCard.PutCard(id, cardDto) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            return _contextCard.DeleteCard(id) ? NoContent() : NotFound();
        }
    }
}
