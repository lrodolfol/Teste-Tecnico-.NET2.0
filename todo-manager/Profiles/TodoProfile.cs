using AutoMapper;
using CardsManagerLib.Models.Data.Dtos;
using todo_manager.Models.Entitie;

namespace todo_manager.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<CreateCardDto, Todo>();
            CreateMap<Todo, CreateCardDto>();
            CreateMap<Todo, ReadCardDto>()
                .ForMember(dest => dest.Priority, map =>
                map.MapFrom(src => src.NamePrority(src.Priority)));
        }

    }
}
