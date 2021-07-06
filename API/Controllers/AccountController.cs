using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext dataContext;
        public AccountController(DataContext dataContext){
            this.dataContext = dataContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> RegisterUser(RegisterDto registerDto){
            
            if(await this.UserExists(registerDto.Username)){
                return BadRequest("Username is taken");
            }

            using var hmac = new HMACSHA512();
            
            var user = new AppUser{
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            this.dataContext.Add(user);  
            await this.dataContext.SaveChangesAsync();
            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(LoginDto loginDto){

            var user = await this.dataContext.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
            if(user == null) return Unauthorized("Invalid Username or Password");
        
            using var hmac = new HMACSHA512(user.PasswordSalt); 
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int x =0; x < computedHash.Length; x++){
                if(computedHash[x] != user.PasswordHash[x]) return Unauthorized("Invalid Username or Password");
            }
            return user;
        }

        private async Task<bool> UserExists(string username){
            return await this.dataContext.Users.AnyAsync(user =>  user.UserName == username.ToLower());
        }

    }
}