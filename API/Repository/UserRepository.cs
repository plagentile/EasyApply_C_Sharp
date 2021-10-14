using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {

        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly IMapper mapper;

        public UserRepository(UserManager<Users> userManager, SignInManager<Users> signInManager, IMapper mapper){
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        public async Task<Users> GetUserByUserName(string username){
            return await this.userManager.FindByNameAsync(username); 
        }

        public async Task<IEnumerable<Users>> GetUsersAsync(){
            return await this.userManager.Users.ToListAsync<Users>();
        }

        public async Task<IdentityResult> AddUser(RegisterDto registerDto){
           Users user = this.mapper.Map<Users>(registerDto);
           return await userManager.CreateAsync(user, registerDto.Password);        
        }
    }
}