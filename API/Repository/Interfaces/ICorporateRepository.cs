using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Repository.Interfaces
{
    public interface ICorporateRepository
    {
         
        Task<CorporateDto> GetCorporateDtoByUsername(string username);
        Task<IEnumerable<CorporateDto>> GetCorporationsAsDtos();

    }
}