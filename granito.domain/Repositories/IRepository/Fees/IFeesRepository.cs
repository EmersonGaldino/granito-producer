using granito.domain.Entity.Fees;

namespace granito.domain.Repositories.IRepository.Fees;

public interface IFeesRepository
{
    Task<FeesSchema> Get();
}