using granito.application.Interface.Fees;
using granito.domain.Entity.Fees;
using granito.domain.Interface.Fees;

namespace granito.application.AppService.Fees;

public class FeesAppService : IFeesAppService
{
    private readonly IFeesService service;
    public FeesAppService(IFeesService service)
    {
        this.service = service;
    }

    public async Task<FeesSchema> Get() => await service.Get();

}