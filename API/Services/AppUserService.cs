using System.Threading.Tasks;
using API.Data;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AppUserService : IAppUsersService
    {
        
        private readonly DataContext dataContext;

        public AppUserService(DataContext dataContext){
            this.dataContext = dataContext;
        }

        public async Task<bool> UserExists(string username){
            return await this.dataContext.Users.AnyAsync(user => user.UserName == username.ToLower());
        }

    }
}