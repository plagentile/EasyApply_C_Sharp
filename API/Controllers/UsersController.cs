using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces.Repository;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class UsersController : BaseApiController
    {

        private readonly IUsersService usersService;
        private readonly IMapper mapper;

        public UsersController(IMapper mapper, IUsersService usersService){
            this.mapper = mapper;
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await this.usersService.GetUsersAsync();
            var usersToDto = mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersToDto);
        }

        [HttpGet("{username}")]
        public async Task<UserDto> GetUserById(string username){
            var user = await this.usersService.GetUserByUsername(username);
            return this.mapper.Map<UserDto>(user);
        }
    }
}