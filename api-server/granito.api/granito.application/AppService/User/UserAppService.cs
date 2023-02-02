using granito.application.Interface.User;
using granito.domain.Entity.User;
using granito.domain.Interface.User;

namespace granito.application.AppService.User;

public class UserAppService: IUserAppService
{
    private IUserService Service;
   
    public UserAppService(IUserService service)
    {
        this.Service = service;
        
    }

    public async Task<UserEntity> GetUser(UserEntity model) => await Service.GetUser(model);


    
}