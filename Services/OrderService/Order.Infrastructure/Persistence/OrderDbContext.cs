using Microsoft.EntityFrameworkCore;
using OrderEntity = Order.Domain.Entities.Order;
using CustomerEntity = Order.Domain.Entities.Customer;

namespace Order.Infrastructure.Persistence;

public sealed class OrderDbContext : DbContext
{
    public OrderDbContext(
        DbContextOptions<OrderDbContext> options)
        : base(options)
    {
    }


    public DbSet<OrderEntity> Orders => Set<OrderEntity>();
    public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();


    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderEntity>(entity =>
        {
            entity.ToTable("orders");

            entity.HasKey(x => x.Id);


            entity.Property(x => x.CustomerId)
                .IsRequired();


            entity.Property(x => x.CreatedAt)
                .IsRequired();
        });

        modelBuilder.Entity<CustomerEntity>(entity =>
        {
            entity.ToTable("customers");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Email)
                .HasMaxLength(200)
                .IsRequired();
        });
    }
}