using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ApplicantController : BaseApiController
    {

        private readonly IApplicantService applicantService;
        private readonly IUsersService userService;

        public ApplicantController(IApplicantService applicantService, IUsersService userService){
            this.applicantService = applicantService;
            this.userService = userService;
        }

        [HttpPost("registerApplicant")]
        public async Task<ActionResult<UserDto>> RegisterApplicant(RegisterDto registerDto){
            if (await this.userService.UserExists(registerDto.Username)){
                return BadRequest("Username is taken");
            }
            return await this.applicantService.RegisterApplicant(registerDto);
        }

        [HttpPost("loginApplicant")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto){
            
            UserDto user = await this.applicantService.LoginApplicant(loginDto);
            if (user == null) return Unauthorized("Invalid Username or Password");
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicantDto>>> GetApplicants(){
            return Ok(await this.applicantService.GetApplicantsMappedAsDto());
        }
    }
}