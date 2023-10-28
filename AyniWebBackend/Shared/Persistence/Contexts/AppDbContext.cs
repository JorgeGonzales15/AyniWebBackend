using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AyniWebBackend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(120);
        builder.Entity<Product>().Property(p => p.UnitPrice).IsRequired();
        builder.Entity<Product>().Property(p => p.Quantity).IsRequired();
        builder.Entity<Product>().Property(p => p.ImageUrl).IsRequired().HasMaxLength(50);

        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().Property(p => p.Id);
        builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(p => p.Description).HasMaxLength(120);
        builder.Entity<Order>().Property(p => p.Status).HasMaxLength(50);
        builder.Entity<Order>().Property(p => p.OrderedDate).IsRequired().HasMaxLength(50);
        builder.Entity<Order>().Property(p => p.TotalPrice).IsRequired();
        builder.Entity<Order>().Property(p => p.PaymentMethod).IsRequired().HasMaxLength(50);
        
        builder.Entity<User>()
            .HasMany(p => p.Orders )
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        builder.Entity<Product>()
            .HasMany(p=>p.Orders)
            .WithOne(p=>p.Product)
            .HasForeignKey(p=>p.ProductId);





        builder.UseSnakeCaseNamingConvention();
    }
}