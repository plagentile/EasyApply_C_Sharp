using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Repository.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class JobPostingRepository : IJobPostingRepository
    {

        private readonly IMapper mapper;
        private readonly DataContext dataContext;

        public JobPostingRepository(DataContext dataContext, IMapper mapper){
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<JobPostingDto>> GetJobPostingsByCorprateId(int corporateId){
            return await this.dataContext.JobPostings.Where(posting => posting.CorporationId == corporateId).ProjectTo<JobPostingDto>(this.mapper.ConfigurationProvider).ToListAsync();
        }
    }
}