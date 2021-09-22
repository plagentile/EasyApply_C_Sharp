using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Services.Interfaces
{
    public interface IJobPostingService{
         Task<IEnumerable<JobPostingDto>> GetJobPostingsByCorporateId(int corporateId);
    }
}