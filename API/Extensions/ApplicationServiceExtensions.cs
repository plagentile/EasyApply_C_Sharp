using API.Data;
using API.Interfaces;
using API.Interfaces.Repository;
using API.Services;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration iConfig){
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IUsersService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            
            services.AddDbContext<DataContext>(options => 
            {
                options.UseSqlite(iConfig.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}