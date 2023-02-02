namespace granito.repository.Repository.Base;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    #region .::Constructor

    protected readonly IMongoContext Context;
    protected IMongoCollection<TEntity> DbSet;

    protected BaseRepository(IMongoContext context)
    {
        Context = context;
        DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    #endregion


    #region .::Methods

    public virtual void Add(TEntity obj)
    {
        Context.AddCommand(() => DbSet.InsertOneAsync(obj));
    }


    public virtual void SaveAsync(TEntity obj)
    {
        DbSet.InsertOneAsync(obj);
        Context.Dispose();
    }

    public virtual async Task<TEntity> GetById(string id)
    {
        var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
        return data.SingleOrDefault();
    }

    public virtual async Task<IList<TEntity>> GetAll()
    {
        var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
        return all.ToList();
    }

    public virtual void Update(TEntity obj, string id)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        DbSet.ReplaceOneAsync(filter, obj);
        Dispose();
    }

    public virtual async Task Remove(string id)
    {
        await DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("orderId", id));
        Context.Dispose();
    }

    public virtual async Task RemoveAll()
    {
        await DbSet.DeleteManyAsync(Builders<TEntity>.Filter.Eq("{}", ""));
        Context.Dispose();
    }

    public async Task<TEntity> FindDescription(string search)
    {
        var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("description", search));
        return data.SingleOrDefault();
    }

    public void Dispose() => Context?.Dispose();

    #endregion
}