using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using todo_manager.Models.Data.Dtos;
using todo_manager.Models.Entitie;
using todo_manager.Models.Interfaces;

namespace todo_manager.Models.Data
{
    public class ContextCard : IContextCard
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ContextCard(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                 orderby todo.IdPriority descending
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
    }
}
