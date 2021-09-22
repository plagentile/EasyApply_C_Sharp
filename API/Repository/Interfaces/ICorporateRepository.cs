using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Repository.Interfaces
{
    public interface ICorporateRepository
    {
         
        Task<CorporateDto> GetCorporationByUsername(string username);
        Task<IEnumerable<CorporateDto>> GetCorporationsAsDtos();
        Task<IEnumerable<CorporateDto>> GetCorporationsAsDtosWithNameLike(string corporateName);

    }
}