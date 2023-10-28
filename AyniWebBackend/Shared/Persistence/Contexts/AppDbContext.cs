using AyniWebBackend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AyniWebBackend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);




        builder.UseSnakeCaseNamingConvention();
    }
}