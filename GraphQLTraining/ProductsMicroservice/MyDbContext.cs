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
                builder.OwnsOne(x => x.Pricing);
                builder.OwnsOne(x => x.Metadata);
                builder.OwnsMany(p => p.Relationships, relationship =>
                {
                    relationship.OwnsMany(x => x.RelatedProducts);
                });
                builder.OwnsOne(p => p.Site, site =>
                {
                    site.ToJson();
                    site.OwnsOne(x => x.Currency);
                });
                
                builder.OwnsOne(p => p.Media, p =>
                {
                    p.OwnsMany(x => x.Items, item =>
                    {
                        item.OwnsOne(x => x.WistiaVideo);
                        item.OwnsOne(x => x.ThreeSixtyWistiaVideo);
                        item.OwnsOne(x => x.CdnImages, cdnImages =>
                        {
                            cdnImages.OwnsOne(x => x.Medium);
                            cdnImages.OwnsOne(x => x.Original);
                        });
                    });
                });

                builder.OwnsOne(x => x.ProductionInfo, productionInfo =>
                {
                    productionInfo.OwnsOne(x => x.BoxSize);
                    productionInfo.OwnsOne(x => x.ProductSizeHsCode);
                });

                builder.OwnsMany(x => x.Categories, category =>
                {
                    category.OwnsMany(x => x.ShowAndHides);
                    category.OwnsMany(x => x.Labels);
                    category.OwnsOne(x => x.CustomizationTemplate);
                    category.OwnsMany(x => x.Fields);
                    category.OwnsMany(x => x.Options, options =>
                    {
                        options.OwnsOne(x => x.Image);
                        options.OwnsOne(x => x.RelatedProduct, relatedProduct =>
                        {
                            relatedProduct.OwnsOne(x => x.Pricing);
                        });
                    });

                });

                builder.OwnsMany(x => x.CategoryRibbons);
                builder.OwnsMany(x => x.ProductRibbons);
            });
        
    }
}