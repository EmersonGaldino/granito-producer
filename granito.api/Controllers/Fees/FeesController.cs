
using AutoMapper;
using granito.api.Models.ModelView.Fees;
using granito.application.Interface.Fees;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[Route("api/[controller]")]
[ApiController]
public class FeesController : ApiBaseController
{
    private IMapper Mapper => GetService<IMapper>();
    private IFeesAppService AppService => GetService<IFeesAppService>();
    
    [HttpGet]
    [SwaggerOperation(Summary = "Get Fees",
        Description = "Buscar taxa de juros.")]
    [SwaggerResponse(200, "Juros.", typeof(SuccessResponse<BaseModelView<FeesModelView>>))]
    [SwaggerResponse(400, "Não foi possível buscar o juros do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Get() => await AutoResult(async () => new BaseModelView<FeesModelView>
    {
        Data = Mapper.Map<FeesModelView>(await AppService.Get()),
        Message = "Value fess",
        Success = true
    });
}