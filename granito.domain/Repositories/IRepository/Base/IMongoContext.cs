using MongoDB.Driver;

namespace showMeMicroservice.domain.Repositories.IRepository.Base;

public interface IMongoContext : IDisposable
{
    void AddCommand(Func<Task> func);
    Task<int> SaveChanges();
    IMongoCollection<T> GetCollection<T>(string name);
}