using granito.domain.Entity.Fees;

namespace granito.domain.Interface.Fees;

public interface IFeesService
{
    Task<FeesSchema> Get();
}