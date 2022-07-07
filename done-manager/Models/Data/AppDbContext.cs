using done_manager.Models.Entitie;
using Microsoft.EntityFrameworkCore;

namespace done_manager.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
        public DbSet<Done> Done { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
