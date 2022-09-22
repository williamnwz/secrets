using MySecrets.Application.Dto.Users;

namespace MySecrets.Application.Services.Interfaces
{
    public interface IUserAppService
    {
        Task RegisterUserAsync(RegisterUserDto registerUser);
        Task InviteUserAsync(string email);
        Task RemoveUserAsync(string id);
    }
}
