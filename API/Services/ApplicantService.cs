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
        private readonly IAppUsersService appUsersService;

        public ApplicantService(DataContext dataContext, ITokenService itokenService, IAppUsersService appUsersService)
        {
            this.dataContext = dataContext;
            this.itokenService = itokenService;
            this.appUsersService = appUsersService;
        }

        public async Task<UserDto> LoginApplicant(LoginDto loginDto)
        {
            AppUsers user = await this.appUsersService.UserCanLogin(loginDto);
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

            var user = new AppUsers
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