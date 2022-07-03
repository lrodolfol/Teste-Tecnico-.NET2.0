using Microsoft.EntityFrameworkCore;
using todo_manager.Models.Entitie;

namespace todo_manager.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<Priority> Priority { get; set; }
        public DbSet<Todo> Todo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Priority>()
                .HasData(
                    new Priority { Id = 1, Name = "baixo" },
                    new Priority { Id = 2, Name = "medio" },
                    new Priority { Id = 3, Name = "alto" }
                );

            builder.Entity<Todo>()
                .HasOne(todo => todo.Priority)
                .WithMany(priority => priority.Todos)
                .HasForeignKey(todo => todo.IdPriority)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
