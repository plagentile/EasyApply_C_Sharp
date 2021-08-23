using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    public class UsersController : BaseApiController
    {
        private readonly DataContext dataContext;
        public UsersController(DataContext dataContext){
            this.dataContext = dataContext;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUsers>>> GetUsers(){
            return await this.dataContext.Users.ToListAsync();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUsers>> GetUserById(int id){
            return await this.dataContext.Users.FindAsync(id);
        }
    }
}