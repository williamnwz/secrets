using MySecrets.Domain.Entities.Users;

namespace MySecrets.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
