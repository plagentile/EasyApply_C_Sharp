using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Services.Interfaces
{
    public interface IAppUsersService{
        Task<bool> UserExists(string username);

        Task<AppUsers> GetUser(LoginDto loginDto);
        Task<AppUsers> UserCanLogin(LoginDto loginDto);
    }
}