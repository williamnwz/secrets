using AutoMapper;
using MySecrets.Application.Dto.Users;
using MySecrets.Domain.Entities.Users;

namespace MySecrets.Application.Profiles
{
    public  class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDto, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(p => p.Email))
                .ForMember(x => x.Login, opt => opt.MapFrom(p => p.Login))
                .ForMember(x => x.Password, opt => opt.MapFrom(p => p.Password));
        }
    }
}
