using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext dataContext;
        public UsersController(DataContext dataContext){
            this.dataContext = dataContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers(){
            return await this.dataContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserById(int id){
            return await this.dataContext.Users.FindAsync(id);
        }
    }
}