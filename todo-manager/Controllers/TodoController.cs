using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using todo_manager.Interfaces;
using todo_manager.Models.Data;
using todo_manager.Models.Data.Dtos;
using todo_manager.Models.Entitie;

namespace todo_manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase, ICardController
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public TodoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostCard([FromBody] CreateCardDto dtoCard)
        {
           try
           {    
                var todoCard = _mapper.Map<Todo>(dtoCard);

                _context.Todo.Add(todoCard);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetCard), new { id = todoCard.Id}, todoCard);
           }
           catch(Exception)
           {
               return StatusCode(500);
           }
            
        }

        [HttpGet]
        public IActionResult GetCard([FromQuery] string title)
        {
            //utilizado para listar os Todos com prioridade de emergência
            List<Todo> cardsTodo = 
                (from todo in _context.Todo
                 orderby todo.IdPriority descending
                 select todo).ToList();

            if (! string.IsNullOrEmpty(title))
            {
                var query = 
                    (from t in cardsTodo
                     where t.title == title
                     select t).ToList();

                cardsTodo = query.ToList();
            }

            List<ReadCardDto> readsCard = _mapper.Map<List<ReadCardDto>>(cardsTodo);

            return Ok(readsCard);
        }

        [HttpGet("{id}")]
        public IActionResult GetCard(int id)
        {
            Todo cardTodo = _context.Todo.FirstOrDefault(t => t.Id == id);

            if (cardTodo == null) 
            {
                return NotFound();
            }

            ReadCardDto readCard = _mapper.Map<ReadCardDto>(cardTodo);

            return Ok(readCard);
        }

        [HttpPut("{id}")]
        public IActionResult PutCard(int id, CreateCardDto dtoCard)
        {
            Todo todoCard = _context.Todo.FirstOrDefault(t => t.Id == id);

            if (todoCard == null)
            {
                return NotFound();
            }

            todoCard = _mapper.Map(dtoCard, todoCard);

            try
            {
                _context.SaveChanges();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            var todo = _context.Todo.FirstOrDefault(t => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            _context.Todo.Remove(todo);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
