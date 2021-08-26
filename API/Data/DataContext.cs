using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Corporation> Corporations { get; set; }
    }
}