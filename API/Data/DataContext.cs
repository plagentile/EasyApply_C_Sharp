using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : IdentityDbContext<
        Users,
        AppRole,
        int, 
        IdentityUserClaim<int>, 
        AppUserRole, 
        IdentityUserLogin<int>, 
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Corporation> Corporations { get; set; }
       
        public DbSet<JobPosting> JobPostings { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Users>()
            .HasMany(ur => ur.userRoles)
            .WithOne(u => u.user)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

             builder.Entity<AppRole>()
            .HasMany(ur => ur.userRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

        }
    }
}