using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces.Repository
{
    public interface IUserRepository
    {
        void UpdateUser(Users user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<Users>> GetUsersAsync();

        Task<Users> GetUserByIdAsync(int id);

        Task<Users> GetUserByUsername(string username);
    }
}