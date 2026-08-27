using CustomerEntity = Customer.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Persistence;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(
        DbContextOptions<CustomerDbContext> options)
        : base(options)
    {
    }


    public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();


    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
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