using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Services.Interfaces
{
    public interface IUsersService{
        Task<bool> UserExists(string username);
        Task<Users> GetUser(LoginDto loginDto);
        Task<Users> UserCanLogin(LoginDto loginDto);
        Task<Users> GetUserByUsername(string username);
        Task<IEnumerable<Users>> GetUsersAsync();
    }
}