using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext){
            this.dataContext = dataContext;
        }

        public async Task<Users> GetUserByIdAsync(int id){
            return await this.dataContext.Users.FindAsync(id);
        }

        public async Task<Users> GetUserByUsername(string username){
            return await this.dataContext.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<Users>> GetUsersAsync(){
            return await this.dataContext.Users.ToListAsync();
        }

        public async Task<bool> SaveAllAsync(){
            return await dataContext.SaveChangesAsync() > 0;
        }

        public void UpdateUser(Users user){
            this.dataContext.Entry(user).State = EntityState.Modified;
        }
    }
}