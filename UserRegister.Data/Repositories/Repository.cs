using Microsoft.EntityFrameworkCore;
using UserRegister.Data.AppsDbContext;
using UserRegister.Data.IRepositories;
using UserRegister.Domain.Commons;
using UserRegister.Domain.Entities;

namespace UserRegister.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<TEntity> dbSet;
    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        this.dbSet = appDbContext.Set<TEntity>();
    }
    public async Task DeleteAsync(long id)
    {
        var entity = await this.dbSet.FirstOrDefaultAsync(e => e.Id == id);
        this.dbSet.Remove(entity);

    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var person = await this.dbSet.AddAsync(entity);

        return person.Entity;
    }

    public async Task<bool> SaveChangeAsync()
        => await this.appDbContext.SaveChangesAsync() > 0;
    

    public IQueryable<TEntity> SelectAll()
        => this.dbSet;


    public async Task<TEntity> SelectByIdAsync(long id) 
        => await this.dbSet.FirstOrDefaultAsync(e => e.Id == id);


    public void UpdateAsync(TEntity entity)
        => this.dbSet.Update(entity);
    
}
