using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepository jobPostingRepository;

        public JobPostingService(IJobPostingRepository jobPostingRepository){
            this.jobPostingRepository = jobPostingRepository;
        }

        public async Task<ActionResult<IEnumerable<JobPostingDto>>> GetJobPostingsByCorporateId(int corporateId){
            return await this.jobPostingRepository.GetJobPostingsByCorprateId(corporateId);
        }
    }
}