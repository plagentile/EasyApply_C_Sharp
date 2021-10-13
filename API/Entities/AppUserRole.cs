using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public Users user { get; set; }

        public AppRole Role { get; set; }
    }
}