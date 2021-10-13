using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class Users : IdentityUser<int>
    {
        public ICollection<AppUserRole> userRoles { get; set; }
    }
}