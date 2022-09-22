using MySecrets.CrossCutting.Emails;
using MySecrets.Domain.Entities.Users;

namespace MySecrets.Domain.Services.Interfaces
{
    public interface IUserRegisterEmailBuilder
    {
        Task<IEmailMessage> Build(User user);
    }
}
