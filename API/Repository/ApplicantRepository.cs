using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicantRepository : IApplicantRepository
    {

        private readonly DataContext dataContext;

        public ApplicantRepository(DataContext dataContext){
            this.dataContext = dataContext;
        }

        public async Task<Applicant> GetApplicantByIdAsync(int id){
             return await this.dataContext.Applicants.FindAsync(id);
        }

        public async Task<Applicant> GetApplicantByUsername(string username){
            return await this.dataContext.Applicants.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<Applicant>> GetApplicantsAsync()
        {
            return await this.dataContext.Applicants.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
             return await dataContext.SaveChangesAsync() > 0;
        }

        public void UpdateAplicant(Applicant applicant)
        {
             this.dataContext.Entry(applicant).State = EntityState.Modified;
        }

        public void UpdateApplicant(Applicant user)
        {
            throw new System.NotImplementedException();
        }
    }
}