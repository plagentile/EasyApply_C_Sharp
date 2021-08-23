using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext dataContext;
        private readonly ITokenService itokenService;
        public AccountController(DataContext dataContext, ITokenService itokenService)
        {
            this.itokenService = itokenService;
            this.dataContext = dataContext;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {

            var user = await this.dataContext.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
            if (user == null) return Unauthorized("Invalid Username or Password");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int x = 0; x < computedHash.Length; x++)
            {
                if (computedHash[x] != user.PasswordHash[x]) return Unauthorized("Invalid Username or Password");
            }
            
            return new UserDto{
                Username = user.UserName,
                Token = this.itokenService.CreateToken(user)
            };
        }

    }
}