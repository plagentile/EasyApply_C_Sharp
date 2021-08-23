using System.Threading.Tasks;
using API.DTOs;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ApplicantController : BaseApiController
    {

        private readonly IApplicantService applicantService;
        private readonly IAppUsersService appUserService;

        public ApplicantController(IApplicantService applicantService, IAppUsersService appUserService){
            this.applicantService = applicantService;
            this.appUserService = appUserService;
        }

        [HttpPost("registerApplicant")]
        public async Task<ActionResult<UserDto>> RegisterApplicant(RegisterDto registerDto){
            if (await this.appUserService.UserExists(registerDto.Username)){
                return BadRequest("Username is taken");
            }

            return await this.applicantService.RegisterApplicant(registerDto);
        }
    }
}