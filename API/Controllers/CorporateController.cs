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
        private readonly IJobPostingService jobPostingService;

        public CorporateController(ICorporateService corporateService, IJobPostingService jobPostingService){
            this.corporateService = corporateService;
            this.jobPostingService = jobPostingService;
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
        public async Task<ActionResult<CorporateDto>> GetCorporationByUsername(string username){ 
            return Ok(await this.corporateService.GetCorporationByUsername(username));
        }

        [HttpGet]
        [Route("getJobPostingsByCorporateId/{id}")]
        public async Task<ActionResult<IEnumerable<JobPostingDto>>> GetJobPostingsByCorporateId(int id){
            return Ok(await this.jobPostingService.GetJobPostingsByCorporateId(id));
        }
    }
}