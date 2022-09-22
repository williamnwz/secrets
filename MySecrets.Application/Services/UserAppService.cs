using MySecrets.Application.Dto.Users;
using MySecrets.Application.Services.Interfaces;

namespace MySecrets.Application.Services
{
    public class UserAppService : IUserAppService
    {
        public UserAppService()
        {
        }

        public Task InviteUserAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task RegisterUserAsync(RegisterUserDto registerUser)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
