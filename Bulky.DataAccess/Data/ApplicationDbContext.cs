using Bulky.Model;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category{ Id = 1,Name="Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Si-Fi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Romance", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
               new Product { Id = 1, Title = "Spy x Family",
                   Author = "someone", Description = "A family with their own secrets and mission unknown to each other.",
                   ISBN = "IS55",
                   ListPrice = 555,
                   Price = 555,
                   Price50 = 540,
                   Price100 = 500}
               );
        }
    }
}
