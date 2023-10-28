using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AyniWebBackend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    
    public DbSet<Cost> Costs { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        
        
        
        
        
        
        
        
        
        
        
        
        builder.Entity<Cost>().ToTable("Costs");
        builder.Entity<Cost>().HasKey(p => p.Id);
        builder.Entity<Cost>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Cost>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Cost>().Property(p => p.Description).HasMaxLength(120);
        builder.Entity<Cost>().Property(p => p.Amount).IsRequired();
        
        builder.Entity<User>()
            .HasMany(p => p.Costs)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);




        builder.UseSnakeCaseNamingConvention();
    }
}