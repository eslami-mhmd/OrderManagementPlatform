using Microsoft.EntityFrameworkCore;
using OrderEntity = Order.Domain.Entities.Order;

namespace Order.Infrastructure.Persistence;

public sealed class OrderDbContext : DbContext
{
    public OrderDbContext(
        DbContextOptions<OrderDbContext> options)
        : base(options)
    {
    }


    public DbSet<OrderEntity> Orders => Set<OrderEntity>();


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
    }
}