using AT.API.DTOs.Users;
using AT.Models;
using AutoMapper;

namespace AT.API.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<UserLoginDto, UserLoginDto>();
            CreateMap<UserLoginDto, UserLogin>();
            CreateMap<Token, TokenDto>()
                .ForMember(m => m.Token, d => d.MapFrom(o => o.BearerToken));
        }
    }
}
