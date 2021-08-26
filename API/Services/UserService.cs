using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUsersService
    {
        
        private readonly DataContext dataContext;

        private readonly ITokenService itokenService;

        public UserService(DataContext dataContext, ITokenService itokenService)
        {
            this.dataContext = dataContext;
            this.itokenService = itokenService;
        }

        public async Task<Users> GetUser(LoginDto loginDto){
            return  await this.dataContext.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
        }

        public async Task<bool> UserExists(string username){
            return await this.dataContext.Users.AnyAsync(user => user.UserName == username.ToLower());
        }

        public async Task<Users> UserCanLogin(LoginDto loginDto){

            Users user = await this.GetUser(loginDto);
            if (user == null) return null;

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int x = 0; x < computedHash.Length; x++){
                if (computedHash[x] != user.PasswordHash[x]) return null;
            }
            
            return user;
        }

    }
}