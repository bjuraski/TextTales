using Microsoft.EntityFrameworkCore;
using Serilog;
using TextTales.Api.Data;

namespace TextTales.Api.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        Log.Information("Applying all pending migrations");

        dbContext.Database.Migrate();
    }
}
