using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Interfaces.Repository;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    
    public class ApplicantService : IApplicantService
    {
        
        private readonly DataContext dataContext;
        private readonly ITokenService itokenService;
        private readonly IUsersService usersService;
        private readonly IApplicantRepository applicantRepository;

        public ApplicantService(DataContext dataContext, ITokenService itokenService, IUsersService usersService, IApplicantRepository applicantRepository)
        {
            this.dataContext = dataContext;
            this.itokenService = itokenService;
            this.usersService = usersService;
            this.applicantRepository = applicantRepository;
        }

        public async Task<IEnumerable<ApplicantDto>> GetApplicantsMappedAsDto(){
            return await this.applicantRepository.GetApplicantsAsDtos();
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
         
            var user = new Users
            {
                UserName = registerDto.Username.ToLower(),
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