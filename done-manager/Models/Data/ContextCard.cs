using AutoMapper;
using CadsManagerLib.Models;
using CardsManagerLib.Interfaces;
using CardsManagerLib.Models.Data.Dtos;
using done_manager.Models.Entitie;

namespace done_manager.Models.Data
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

                Done cardDone = _mapper.Map<Done>(cardDto);

                _context.Done.Add(cardDone);
                this.SaveChanges();

                return cardDone;
            }
            catch
            {
                return null;
            }
        }

        public ReadCardDto GetCardDto(int id)
        {
            Done cardDone = _context.Done.FirstOrDefault(t => t.Id == id);

            if (cardDone == null)
            {
                return null;
            }

            ReadCardDto readCard = _mapper.Map<ReadCardDto>(cardDone);

            return readCard;
        }

        public IEnumerable<ReadCardDto> GetCardsDto(string title = null)
        {
            List<Done> cardsTodo =
                (from todo in _context.Done
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
            Done todoCard = _context.Done.FirstOrDefault(t => t.Id == id);

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
            var todo = _context.Done.FirstOrDefault(t => t.Id == id);

            if (todo == null)
            {
                return false;
            }

            _context.Done.Remove(todo);
            SaveChanges();

            return true;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool ElevateCard(int id)
        {
            throw new NotImplementedException();
        }
    }
}
