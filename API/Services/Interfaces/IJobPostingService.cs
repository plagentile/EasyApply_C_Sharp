using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interfaces
{
    public interface IJobPostingService{
         Task<ActionResult<IEnumerable<JobPostingDto>>> GetJobPostingsByCorporateId(int corporateId);
    }
}