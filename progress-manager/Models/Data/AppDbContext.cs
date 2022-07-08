using Microsoft.EntityFrameworkCore;
using progress_manager.Models.Entitie;

namespace progress_manager.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
        public DbSet<Progress> Progress { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
