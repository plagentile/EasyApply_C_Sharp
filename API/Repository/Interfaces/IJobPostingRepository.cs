using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Repository.Interfaces
{
    public interface IJobPostingRepository
    {
         Task<IEnumerable<JobPostingDto>> GetJobPostingsByCorprateId(int corporateId);
    }
}