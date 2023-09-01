using Microsoft.EntityFrameworkCore;
using TextTales.Api.Entities;

namespace TextTales.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
}
