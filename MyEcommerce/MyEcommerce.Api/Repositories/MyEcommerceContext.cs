using Microsoft.EntityFrameworkCore;
using MyEcommerce.Api.Models;

namespace MyEcommerce.Api.Repositories;

public class MyEcommerceContext : DbContext
{
    public MyEcommerceContext(DbContextOptions<MyEcommerceContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Customer>()
            .ToTable("Customers");

        base.OnModelCreating(builder);
    }
}
