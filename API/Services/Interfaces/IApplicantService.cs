using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interfaces
{
    public interface IApplicantService
    {
        Task<ActionResult<UserDto>> RegisterApplicant(RegisterDto registerDto);

        Task<UserDto> LoginApplicant(LoginDto loginDto);

        Task<IEnumerable<ApplicantDto>> GetApplicantsMappedAsDto();
    }
}