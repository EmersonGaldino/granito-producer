using granito.domain.Entity.User;

namespace granito.application.Interface.User;

public interface IUserAppService
{
    Task<UserEntity> GetUser(UserEntity model);
}