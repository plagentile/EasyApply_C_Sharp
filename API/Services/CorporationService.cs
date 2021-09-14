using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Repository.Interfaces;

namespace API.Services.Interfaces
{
    public class CorporationService : ICorporateService
    {
        private readonly ICorporateRepository corporateRepository;

        public CorporationService(ICorporateRepository corporateRepository)
        {
            this.corporateRepository = corporateRepository;
        }

        public async Task<IEnumerable<CorporateDto>> GetCorporationsMappedAsDto()
        {
            return await this.corporateRepository.GetCorporationsAsDtos();
        }
    }
}