using API.Data;
using API.HelperClasses;
using API.Interfaces.Repository;
using API.Repository;
using API.Repository.Interfaces;
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
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<ICorporateRepository, CorporationRepository>();

            services.AddScoped<ICorporateService, CorporationService>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IUsersService, UserService>();
            services.AddScoped<Interfaces.ITokenService, TokenService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            
            services.AddDbContext<DataContext>(options => 
            {
                options.UseSqlite(iConfig.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}