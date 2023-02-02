using granito.domain.Entity.Fees;
using granito.domain.Repositories.IRepository.Fees;
using granito.repository.Repository.Context;

namespace granito.repository.Repository.Fees;

public class FeesRepository : BaseRepository<FeesSchema>,IFeesRepository
{
    private readonly ContextDb contextDb;
    public FeesRepository(ContextDb contextDb):base(contextDb)
    {
        this.contextDb = contextDb;
    }

    public async Task<FeesSchema> Get()
    {
        return new FeesSchema
        {
            Id = "a9e9bea7eaf6ea26a600080787d0e6030ac9c64b",
            Value = 1
        };
    }
}