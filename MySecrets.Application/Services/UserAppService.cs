using AutoMapper;
using MySecrets.Application.Dto.Users;
using MySecrets.Application.Services.Interfaces;
using MySecrets.Domain.Entities.Users;
using MySecrets.Domain.Repositories;
using MySecrets.Domain.Services.Interfaces;

namespace MySecrets.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository userRepository;
        private readonly IRegisterUserService registerUserService;
        private readonly IMapper mapper;

        public UserAppService(
            IRegisterUserService registerUserService,
            IUserRepository userRepository,
            IMapper mapper)
        {
            this.registerUserService = registerUserService;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }


        public Task InviteUserAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterUserAsync(RegisterUserDto registerUser)
        {
            User userToRegister = mapper.Map<User>(registerUser);

            await this.registerUserService.Register(userToRegister);
        }

        public Task RemoveUserAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
