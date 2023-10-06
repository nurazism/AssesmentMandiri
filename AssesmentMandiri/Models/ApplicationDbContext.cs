using Microsoft.EntityFrameworkCore;

namespace AssesmentMandiri.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }   
        public DbSet<Career> Careers { get; set; }   
        public DbSet<Team> Teams { get; set; }   
    }
}
