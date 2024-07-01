using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Tenengroup.CatalogProxy.Domain.Catalog;

namespace ProductsMicroservice;

public class MyDbContext : DbContext
{
    public DbSet<CatalogProduct> Products { get; set; }
    public DbSet<CustomersContext.Customer> Customers { get; set; }
    
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var p = new Product();
        
        modelBuilder.Entity<CustomersContext.Customer>()
            .OwnsOne(c => c.Details, d =>
            {
                d.ToJson("details"); 
                d.OwnsMany(d => d.Orders, d =>
                {
                    d.OwnsMany(d => d.Items);
                });
            });

        
            modelBuilder.Entity<CatalogProduct>()
            .OwnsOne(c => c.Product, builder =>
            {
                builder.ToJson("datajson");
            
                builder.OwnsOne(p => p.Family);
                builder.OwnsOne(p => p.Site, site =>
                {
                    site.ToJson();
                    site.OwnsOne(x => x.Currency);
                });
                
                builder.OwnsOne(p => p.Media, p =>
                {
                    p.OwnsMany(x => x.Items);
                });
            });
        // foreach (var entity in modelBuilder.Model.GetEntityTypes())
        // {
        //     foreach (var property in entity.GetProperties())
        //     {
        //         property.SetJsonPropertyName(property.GetJsonPropertyName()?.ToSnakeCase());
        //     }
        // }
        //
       
    }
}