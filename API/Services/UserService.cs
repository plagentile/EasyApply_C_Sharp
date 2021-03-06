using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Interfaces.Repository;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUsersService {
        
        private readonly IUserRepository userRepository;

        private readonly ITokenService itokenService;

        public UserService(ITokenService itokenService, IUserRepository userRepository) {
            this.itokenService = itokenService;
            this.userRepository = userRepository;
        }

        public async Task<Users> GetUser(LoginDto loginDto){
            return  await this.userRepository.GetUserByUserName(loginDto.Username);
        }

        public async Task<bool> UserExists(string username){        
            return await this.userRepository.GetUserByUserName(username) != null;
        }

        public async Task<Users> UserCanLogin(LoginDto loginDto){
            Users user = await this.GetUser(loginDto);                    
            return user;
        }
        
        public async Task<Users> GetUserByUsername(string username){
           return await this.userRepository.GetUserByUserName(username);
        }

        public async Task<IEnumerable<Users>> GetUsersAsync(){
            return await this.userRepository.GetUsersAsync();
        }

        public async Task<bool> AddNewUser(RegisterDto registerDto){
           await this.userRepository.AddUser(registerDto);
           return await this.UserExists(registerDto.Username);
        }
    }
}