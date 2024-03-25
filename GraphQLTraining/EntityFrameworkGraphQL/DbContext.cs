using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ProductCustomer> ProductCustomers { get; set; }
    
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCustomer>()
            .HasKey(pc => new { pc.ProductId, pc.CustomerId });
        
        
        modelBuilder.Entity<Product>()
            .HasMany(e => e.Customers)
            .WithMany(e => e.Products)
            .UsingEntity<ProductCustomer>(
                l => l.HasOne<Customer>().WithMany().HasForeignKey(e => e.CustomerId),
                r => r.HasOne<Product>().WithMany().HasForeignKey(e => e.ProductId));

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.CustomerId);
    }
}

[Table("Product", Schema = "dbo")]
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Customer> Customers { get; set; }
}

[Table("Customer", Schema = "dbo")]
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Product> Products { get; set; }
}

[Table("Review", Schema = "dbo")]
public class Review
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}

[Table("ProductCustomer", Schema = "dbo")]
public class ProductCustomer
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}