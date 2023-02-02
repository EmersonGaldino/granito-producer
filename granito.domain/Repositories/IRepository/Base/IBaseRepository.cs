namespace granito.domain.Repositories.IRepository.Base;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    Task<TEntity> GetByIdAsync(string id);
    Task<IList<TEntity>> GetAllAsync();
    Task AddOrUpdateAsync(TEntity entity);
}