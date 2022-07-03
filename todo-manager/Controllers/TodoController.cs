using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using todo_manager.Models.Data;
using todo_manager.Models.Data.Dtos;
using todo_manager.Models.Entitie;
using todo_manager.Models.Interfaces;

namespace todo_manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase, ICardController
    {
        private IMapper _mapper;
        private IContextCard _contextCard;

        public TodoController(IMapper mapper, IContextCard contextCard)
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
        public ActionResult<ReadCardDto> GetCard([FromQuery] string title)
        {
            return Ok(_contextCard.GetCardsDto(title));
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
