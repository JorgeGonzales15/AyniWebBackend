using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AyniWebBackend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Profit> Profits { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>()
            .HasMany(p => p.Profits)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        builder.Entity<Profit>().ToTable("Profits");
        builder.Entity<Profit>().HasKey(p => p.Id);
        builder.Entity<Profit>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profit>().Property(p => p.NameP).IsRequired().HasMaxLength(50);
        builder.Entity<Profit>().Property(p => p.DescriptionP).HasMaxLength(120);
        builder.Entity<Profit>().Property(p => p.AmountP).IsRequired();
        builder.UseSnakeCaseNamingConvention();
    }
}