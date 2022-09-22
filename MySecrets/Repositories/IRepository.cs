using MySecrets.Domain.Entities;

namespace MySecrets.Domain.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> SaveAsync(T entity);
        Task DeleteAsync(T entity);
        T GetByIdAsync(string id);
    }
}
