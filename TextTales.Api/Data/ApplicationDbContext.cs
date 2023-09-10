using Microsoft.EntityFrameworkCore;
using TextTales.Models;

namespace TextTales.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasData(DatabaseInitializer.InitializeCategories());

        modelBuilder.Entity<Product>()
            .HasData(DatabaseInitializer.InitializeProducts());
    }
}
