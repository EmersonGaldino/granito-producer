using granito.domain.Entity.User;

namespace granito.domain.Interface.User;

public interface IUserService
{
    Task<UserEntity> GetUser(UserEntity model);
}