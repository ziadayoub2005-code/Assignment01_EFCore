using BookstoreSystem.Configurations;
using BookstoreSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreSystem.Contexts
{
    public class BookstoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string as requested in the task
            optionsBuilder.UseSqlServer("Server=.;Database=BookstoreDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Part C — Fluent API: Applying configuration class per entity (Clean way)
            modelBuilder.ApplyConfiguration(new BookConfigurations());

            base.OnModelCreating(modelBuilder);
        }

        // DbSets representing database tables
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
