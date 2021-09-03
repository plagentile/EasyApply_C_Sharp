using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class UsersController : BaseApiController
    {
       
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository){
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers(){
            return Ok(await this.userRepository.GetUsersAsync());
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Users>> GetUserById(string username){
            return await this.userRepository.GetUserByUsername(username);
        }
    }
}