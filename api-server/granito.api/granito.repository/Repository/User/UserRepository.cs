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
        var data = await context.User.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
        return data;
    }
}