using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    
    public class ApplicantService : IApplicantService
    {
        
        private readonly DataContext dataContext;
        private readonly ITokenService itokenService;
        private readonly IUsersService usersService;

        public ApplicantService(DataContext dataContext, ITokenService itokenService, IUsersService usersService)
        {
            this.dataContext = dataContext;
            this.itokenService = itokenService;
            this.usersService = usersService;
        }

        public async Task<UserDto> LoginApplicant(LoginDto loginDto)
        {

            /*Login needs to be agnostic or at least know what is going over the wire*/
            Users user = await this.usersService.UserCanLogin(loginDto);
            if (user == null) return null;

            return new UserDto{
                Username = user.UserName,
                Token = this.itokenService.CreateToken(user),
                Role = "Applicant"
            };
        }

        public async Task<ActionResult<UserDto>> RegisterApplicant(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();

            var user = new Users
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                Role = "Applicant"
            };

            this.dataContext.Add(user);
            await this.dataContext.SaveChangesAsync();
            
            return new UserDto{
                Username = user.UserName,
                Token = this.itokenService.CreateToken(user)
            };
        }

    }
}