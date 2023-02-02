using granito.domain.Entity.User;
using granito.domain.Repositories.IService.User;
using granito.repository.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace granito.repository.Repository.User;

public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    private readonly ContextDb context;

    public UserRepository(ContextDb context) : base(context)
    {
        this.context = context;
    }

    public async Task<UserEntity> GetUser(UserEntity model)
    {
        if (model.Email == "emersongaldino@hotmail.com" && model.Password == "123")
            return new UserEntity
            {
                Email = model.Email,
                Company = "Galdino company",
                Id = "927fe2afb197cdbe45a62cd6b8078c30",
                Login = "Galdino"
            };
        return null;
    }
}