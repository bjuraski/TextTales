using Microsoft.EntityFrameworkCore;

namespace TextTales.Api.Data;

public class ApplicationDbContextFactory
{
    private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

    public ApplicationDbContextFactory(DbContextOptions<ApplicationDbContext> dbContextOptions)
    {
        _dbContextOptions = dbContextOptions;
    }

    public ApplicationDbContext CreateDbContext()
    {
        return new ApplicationDbContext(_dbContextOptions);
    }
}
