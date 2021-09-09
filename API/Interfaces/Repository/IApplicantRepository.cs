using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces.Repository
{
    public interface IApplicantRepository
    {
        void UpdateApplicant(Applicant user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<Applicant>> GetUsersAsync();

        Task<Applicant> GetApplicantByIdAsync(int id);

        Task<Applicant> GetApplicantByUsername(string username);
    }
}