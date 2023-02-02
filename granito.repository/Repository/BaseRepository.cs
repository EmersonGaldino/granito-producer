using granito.domain.Entity.Base;
using granito.domain.Repositories.IRepository.Base;
using granito.repository.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace granito.repository.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ContextDb context;
    protected DbSet<TEntity> DbSet;

    public BaseRepository(ContextDb context)
    {
        this.context = context;
        DbSet = context.Set<TEntity>();
    }

    public void Dispose() => GC.SuppressFinalize(this);

    public async Task Add(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await SaveChanges();
    }

    public async Task<TEntity> GetByIdAsync(string id) => await DbSet.FindAsync(id);


    // public async Task<TEntity> GetByIdAsync(Guid id) => await DbSet.FindAsync(id);
    

    public async Task<IList<TEntity>> GetAllAsync()
    {
        var result = await DbSet.ToListAsync();
        return result;
    }

    public async Task Update(TEntity obj)
    {
        DbSet.Update(obj);
        await SaveChanges();
    }

    public async Task Remove(string id)
    {
        var remove = await GetByIdAsync(id);
        context.Remove(remove);
    }

    private async Task SaveChanges()
    {
        await context.SaveChangesAsync();
    }

    public async Task AddOrUpdateAsync(TEntity entity)
    {
        if (entity == null)
            return;

        if (string.IsNullOrEmpty(entity.Id))
            await Add(entity);
        else
            await Update(entity);
    }
}