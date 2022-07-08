using Microsoft.EntityFrameworkCore;
using System;
using todo_manager.Models.Entitie;

namespace todo_manager.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
        public DbSet<Todo> Todo { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
        }
    }
}
