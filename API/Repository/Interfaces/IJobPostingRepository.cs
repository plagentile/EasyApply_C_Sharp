using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Repository.Interfaces
{
    public interface IJobPostingRepository
    {
         Task<ActionResult<IEnumerable<JobPostingDto>>> GetJobPostingsByCorprateId(int corporateId);
    }
}