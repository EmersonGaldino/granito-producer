using granito.domain.Entity.User;
using granito.domain.Repositories.IRepository.Base;

namespace granito.domain.Repositories.IService.User;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<UserEntity> GetUser(UserEntity model);
}