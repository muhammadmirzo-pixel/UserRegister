using UserRegister.Domain.Commons;
using UserRegister.Domain.Entities;

namespace UserRegister.Data.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    Task<bool> SaveChangeAsync();
    Task<TEntity> InsertAsync(TEntity entity);
    void UpdateAsync(TEntity entity);
    Task DeleteAsync(long id);
    Task<TEntity> SelectByIdAsync(long id);
    IQueryable<TEntity> SelectAll();
}