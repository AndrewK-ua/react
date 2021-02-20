using AutoMapper;
using Lab1.Database.Models;
using Lab1.ViewModels;

namespace Lab1.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserLoginViewModel>().ReverseMap();
            CreateMap<UserEntity, UserRegisterViewModel>().ReverseMap();
        }
    }
}
