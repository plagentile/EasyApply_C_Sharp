using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CorporateController : BaseApiController
    {
        
        private readonly ICorporateService corporateService;

        public CorporateController(ICorporateService corporateService){
            this.corporateService = corporateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorporateDto>>> GetCorporations(){
            return Ok(await this.corporateService.GetCorporationsMappedAsDto());
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<IEnumerable<CorporateDto>>> GetCorporationsWithUsernamesLike(string username){
            return Ok(await this.corporateService.GetCorporationsWithNameLike(username));
        }

        [HttpGet]
        [Route("getCorporationByUsername/{username}")]
        public CorporateDto GetCorporationByUsername(string username){
            
            
            CorporateDto dummy = new CorporateDto{Id = 0, UserName = "CoolUsernameBruh"};
            return dummy;
        }
    }
}