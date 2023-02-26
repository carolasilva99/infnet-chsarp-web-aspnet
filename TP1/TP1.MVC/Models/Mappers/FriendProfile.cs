using AutoMapper;
using TP1.Domain;

namespace TP1.MVC.Models.Mappers
{
    public class FriendProfile : Profile
    {
        public FriendProfile()
        {
            CreateMap<Friend, FriendViewModel>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.Name} {src.LastName}")
                )
                .ForMember(
                    dest => dest.BirthDate,
                    opt => opt.MapFrom(src => $"{src.BirthDate}")
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                );
        }
    }
}
