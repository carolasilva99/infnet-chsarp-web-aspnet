using AT.Models;
using AT.MVC.Models.Account;
using AutoMapper;

namespace AT.MVC.Mapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<LoginViewModel, UserEmailLogin>();
            CreateMap<CreateViewModel, User>();
        }
    }
}
