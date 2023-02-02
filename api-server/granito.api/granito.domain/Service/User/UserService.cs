using granito.domain.Entity.User;
using granito.domain.Interface.User;
using granito.domain.Repositories.IService.User;

namespace uCondo.Galdino.Domain.Service.User;

public class UserService : IUserService
{
    private readonly IUserRepository Repository;
    public UserService(IUserRepository repository)
    {
        this.Repository = repository;
    }

    public async Task<UserEntity> GetUser(UserEntity model) =>
            await Repository.GetUser(model);
      
        
   
}