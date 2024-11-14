using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Domain.Entities;

namespace SimpleBookCatalog.Infrastructure.Context
{
    public class SimpleBookCatalogDbContext : DbContext
    {
        public SimpleBookCatalogDbContext(DbContextOptions<SimpleBookCatalogDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(b => b.Author).IsRequired().HasMaxLength(100);
        }
    }  
    
}
