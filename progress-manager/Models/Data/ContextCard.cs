using AutoMapper;
using CadsManagerLib.Models;
using CardsManagerLib.Interfaces;
using CardsManagerLib.Models.Data.Dtos;
using progress_manager.Models.Entitie;

namespace progress_manager.Models.Data
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

                Progress cardTodo = _mapper.Map<Progress>(cardDto);

                _context.Progress.Add(cardTodo);
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
            Progress cardTodo = _context.Progress.FirstOrDefault(t => t.Id == id);

            if (cardTodo == null)
            {
                return null;
            }

            ReadCardDto readCard = _mapper.Map<ReadCardDto>(cardTodo);

            return readCard;
        }

        public IEnumerable<ReadCardDto> GetCardsDto(string title = null)
        {
            List<Progress> cardsTodo =
                (from todo in _context.Progress
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
            Progress todoCard = _context.Progress.FirstOrDefault(t => t.Id == id);

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
            var todo = _context.Progress.FirstOrDefault(t => t.Id == id);

            if (todo == null)
            {
                return false;
            }

            _context.Progress.Remove(todo);
            SaveChanges();

            return true;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
