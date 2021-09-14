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
    public class CorporationRepository : ICorporateRepository
    {

        private readonly IMapper mapper;
        private readonly DataContext dataContext;

        public CorporationRepository(IMapper mapper, DataContext dataContext){
            this.mapper = mapper;
            this.dataContext = dataContext;
        }

        public async Task<CorporateDto> GetCorporateDtoByUsername(string username)
        {
            return await this.dataContext.Corporations
            .Where(x => x.UserName == username)
            .ProjectTo<CorporateDto>(this.mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CorporateDto>> GetCorporationsAsDtos()
        {
            return await this.dataContext.Corporations.ProjectTo<CorporateDto>(this.mapper.ConfigurationProvider).ToListAsync();
        }
    }
}