using eLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
