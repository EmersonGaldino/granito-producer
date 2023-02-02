using granito.domain.Entity.Base;

namespace granito.domain.Entity.User;

public class UserEntity : BaseEntity
{
    public string Company { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public string AssingKey { get; set; }
}