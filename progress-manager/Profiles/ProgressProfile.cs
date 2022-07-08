using AutoMapper;
using CardsManagerLib.Models.Data.Dtos;
using progress_manager.Models.Entitie;

namespace todo_manager.Profiles
{
    public class ProgressProfile : Profile
    {
        public ProgressProfile()
        {
            CreateMap<CreateCardDto, Progress>();
            CreateMap<Progress, ReadCardDto>()
                .ForMember(dest => dest.Priority, map =>
                map.MapFrom(src => src.NamePrority(src.Priority)));
        }

    }
}
