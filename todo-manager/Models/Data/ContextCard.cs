using AutoMapper;
using CadsManagerLib.Models;
using CardsManagerLib.Interfaces;
using CardsManagerLib.Models.Data.Dtos;
using System.Collections.Generic;
using System.Linq;
using todo_manager.Models.Entitie;
using todo_manager.RabbitMq;

namespace todo_manager.Models.Data
{
    public class ContextCard : IContextCard
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private IRabbitMqClient _rabbitMqClient;

        public ContextCard(AppDbContext context, IMapper mapper, IRabbitMqClient rabbitMqClient)
        {
            _context = context;
            _mapper = mapper;
            _rabbitMqClient = rabbitMqClient;
        }

        public Card PostCard(CreateCardDto cardDto)
        {
            try
            {
                if (cardDto == null)
                {
                    return null;
                }

                Todo cardTodo = _mapper.Map<Todo>(cardDto);

                _context.Todo.Add(cardTodo);
                this.SaveChanges();

                return cardTodo;
            }
            catch
            {
                return null;
            }
        }

        public ReadCardDto GetCardDto(int id)
        {
            Todo cardTodo = _context.Todo.FirstOrDefault(t => t.Id == id);

            if (cardTodo == null)
            {
                return null;
            }

            ReadCardDto readCard = _mapper.Map<ReadCardDto>(cardTodo);

            return readCard;
        }

        public IEnumerable<ReadCardDto> GetCardsDto(string title = null)
        {
            List<Todo> cardsTodo =
                (from todo in _context.Todo
                 orderby todo.Priority descending
                 select todo).ToList();

            if (!string.IsNullOrEmpty(title))
            {
                var query =
                    (from t in cardsTodo
                     where t.Title.ToLower() == (title).ToLower()
                     select t).ToList();

                cardsTodo = query.ToList();
            }

            IList<ReadCardDto> readsCard = _mapper.Map<IList<ReadCardDto>>(cardsTodo);

            return (readsCard);
        }

        public bool PutCard(int id, CreateCardDto cardDto)
        {
            Todo todoCard = _context.Todo.FirstOrDefault(t => t.Id == id);

            if (todoCard == null)
            {
                return false;
            }

            todoCard = _mapper.Map(cardDto, todoCard);

            SaveChanges();

            return true;
        }

        public bool DeleteCard(int id)
        {
            var todo = _context.Todo.FirstOrDefault(t => t.Id == id);

            if (todo == null)
            {
                return false;
            }

            _context.Todo.Remove(todo);
            SaveChanges();

            return true;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool ElevateCard(int id)
        {
            Todo cardTodo = _context.Todo.FirstOrDefault(t => t.Id == id);
            if (cardTodo == null)
            {
                return false;
            }

            ReadCardDto cardDto = _mapper.Map<ReadCardDto>(cardTodo);

            //publicar com rabbitmq
            _rabbitMqClient.PublicarElevateCard(cardDto);
            return true;
            _context.Todo.Remove(cardTodo);
            SaveChanges();

            return true;
        }

    }
}
