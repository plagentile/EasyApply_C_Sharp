using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUser(RegisterDto registerDto);
        Task<IEnumerable<Users>> GetUsersAsync();
        Task<Users> GetUserByUserName(string username);
    }
}