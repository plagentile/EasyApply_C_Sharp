using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Services.Interfaces
{
    public interface ICorporateService
    {
        Task<IEnumerable<CorporateDto>> GetCorporationsMappedAsDto();
        Task<IEnumerable<CorporateDto>> GetCorporationsWithNameLike(string corporateName);
        Task<CorporateDto> GetCorporationByUsername(string username);
    }
}