using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AyniWebBackend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    
    public DbSet<Crop> Crops { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Crop>().ToTable("Crops");
        builder.Entity<Crop>().HasKey(p => p.Id);
        builder.Entity<Crop>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Crop>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Crop>().Property(p => p.Description).HasMaxLength(120);
        builder.Entity<Crop>().Property(p=>p.Distance).IsRequired().HasMaxLength(50);
        builder.Entity<Crop>().Property(p=>p.Depth).IsRequired().HasMaxLength(50);
        builder.Entity<Crop>().Property(p=>p.Weather).IsRequired().HasMaxLength(50);
        builder.Entity<Crop>().Property(p=>p.GroundType).IsRequired().HasMaxLength(50);
        builder.Entity<Crop>().Property(p=>p.Season).IsRequired().HasMaxLength(50);
        builder.Entity<Crop>().Property(p=>p.ImageUrl).IsRequired().HasMaxLength(50);

        builder.Entity<User>()
            .HasMany(p => p.Crops)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        builder.UseSnakeCaseNamingConvention();
    }
}