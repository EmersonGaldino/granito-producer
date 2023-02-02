using granito.domain.Entity.Fees;
using granito.domain.Interface.Fees;
using granito.domain.Repositories.IRepository.Fees;

namespace granito.domain.Service.Fees;

public class FeesService : IFeesService
{
    private readonly IFeesRepository Repository;

    public FeesService(IFeesRepository Repository)
    {
        this.Repository = Repository;
    }

    public async Task<FeesSchema> Get() => await Repository.Get();

}