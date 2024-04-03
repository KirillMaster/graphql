using Microsoft.EntityFrameworkCore;

namespace ProductsMicroservice;

public class MyDbContext : DbContext
{
    public DbSet<CatalogProduct> Products { get; set; }
    
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    { }

}