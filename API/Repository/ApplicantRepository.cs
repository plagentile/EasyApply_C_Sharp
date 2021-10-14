using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicantRepository : IApplicantRepository
    {

        private readonly DataContext dataContext;
        private readonly IMapper mapper;


        public ApplicantRepository(DataContext dataContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dataContext = dataContext;
        }

        public async Task AddApplicant(Users user){
            this.dataContext.Add(user);
            await this.dataContext.SaveChangesAsync();
        }

        public async Task<Applicant> GetApplicantByIdAsync(int id){
            return await this.dataContext.Applicants.FindAsync(id);
        }

        public async Task<Applicant> GetApplicantByUsername(string username){
            return await this.dataContext.Applicants.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<ApplicantDto> GetApplicantDtoByUsername(string username){
            return await this.dataContext.Applicants
            .Where(x => x.UserName == username)
            .ProjectTo<ApplicantDto>(this.mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ApplicantDto>> GetApplicantsAsDtos(){
            return await this.dataContext.Applicants.ProjectTo<ApplicantDto>(this.mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<Applicant>> GetApplicantsAsync(){
            return await this.dataContext.Applicants.ToListAsync();
        }

        public async Task<bool> SaveAllAsync(){
            return await dataContext.SaveChangesAsync() > 0;
        }

        public void UpdateAplicant(Applicant applicant){
            this.dataContext.Entry(applicant).State = EntityState.Modified;
        }

        public void UpdateApplicant(Applicant user){
            throw new System.NotImplementedException();
        }
    }
}