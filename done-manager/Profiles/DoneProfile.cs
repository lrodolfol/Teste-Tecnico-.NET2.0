using AutoMapper;
using CardsManagerLib.Enums;
using CardsManagerLib.Models.Data.Dtos;
using done_manager.Models.Entitie;

namespace done_manager.Profiles
{
    public class DoneProfile : Profile
    {
        public DoneProfile()
        {
            CreateMap<CreateCardDto, Done>();
            CreateMap<Done, ReadCardDto>()
                .ForMember(dest => dest.Priority, map =>
                map.MapFrom(src => src.NamePrority(src.Priority)));
        }
    }
}
