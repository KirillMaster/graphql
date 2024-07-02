using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using ProductsMicroservice.ManyJsonbColumns;
using Tenengroup.CatalogProxy.Domain.Catalog;

namespace ProductsMicroservice;

public class MyDbContext : DbContext
{
    public DbSet<CatalogProduct> Products { get; set; }
    
    public DbSet<ProductsMicroservice.ManyJsonbColumns.CatalogProduct> ProductsSliced { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ManyJsonbColumns();
    }
}