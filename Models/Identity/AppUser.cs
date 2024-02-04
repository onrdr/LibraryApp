using Microsoft.AspNetCore.Identity;
using Models.Entities.Abstract;

namespace Models.Identity;

public class AppUser : IdentityUser<Guid>, IBaseEntity
{

}
