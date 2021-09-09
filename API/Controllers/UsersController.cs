using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class UsersController : BaseApiController
    {

        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await this.userRepository.GetUsersAsync();
            var usersToDto = mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersToDto);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserDto>> GetUserById(string username)
        {
            var user = await this.userRepository.GetUserByUsername(username);
            return this.mapper.Map<UserDto>(user);
        }
    }
}