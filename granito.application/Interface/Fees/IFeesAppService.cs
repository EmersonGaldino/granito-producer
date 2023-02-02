using granito.domain.Entity.Fees;

namespace granito.application.Interface.Fees;

public interface IFeesAppService
{
    Task<FeesSchema> Get();
}