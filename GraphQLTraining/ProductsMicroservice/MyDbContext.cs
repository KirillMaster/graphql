using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;
using Tenengroup.CatalogProxy.Domain.Catalog;

namespace ProductsMicroservice;

public class MyDbContext : DbContext
{
    public DbSet<CatalogProduct> Products { get; set; }
    
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var p = new Product();
        modelBuilder.Entity<CatalogProduct>()
            .OwnsOne(c => c.Product, builder =>
            {
                builder.ToJson("datajson");
                builder.OwnsOne(p => p.Family, b =>
                    b.HasJsonPropertyName("family"));
            });
        
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                property.SetJsonPropertyName(property.GetJsonPropertyName()?.ToSnakeCase());
            }
        }
        
        // modelBuilder.Entity<CdnImage>()
        //     .HasNoKey();
        // modelBuilder.Entity<CdnImageDimensions>()
        //     .HasNoKey()
        //     .Ignore(x => x.Medium)
        //     .Ignore(x => x.Original);
        // modelBuilder.Entity<ProductMedia>()
        //     .HasNoKey()
        //     .Ignore(x => x.Items);
        // modelBuilder.Entity<DigitalAsset>()
        //     .HasNoKey()
        //     .Ignore(x => x.WistiaVideo)
        //     .Ignore(x => x.ThreeSixtyWistiaVideo)
        //     .Ignore(x => x.CdnImages);
        // modelBuilder.Entity<Currency>()
        //     .HasNoKey();
        // modelBuilder.Entity<Site>()
        //     .Ignore(x => x.Currency);
        // modelBuilder.Entity<Image>()
        //     .HasNoKey();
        // modelBuilder.Entity<Metadata>()
        //     .HasNoKey();
        // modelBuilder.Entity<ProductPricing>()
        //     .HasNoKey();
        // modelBuilder.Entity<ProductionInfo>()
        //     .HasNoKey();
        // modelBuilder.Entity<RelatedProductPricing>()
        //     .HasNoKey();
        //
        // modelBuilder.Entity<SwitchProduct>()
        //     .Ignore(c => c.Pricing);
        // modelBuilder.Entity<WistiaVideo>()
        //     .HasNoKey();



        // modelBuilder.Entity<CatalogProduct>()
        //     .OwnsOne(c => c.datajson, d =>
        //     {
        //         d.ToJson();
        //         d.OwnsOne(p => p.Family);
        //         d.OwnsOne(p => p.Site, site =>
        //         {
        //             site.ToJson();
        //             site.OwnsOne(x => x.Currency, builder => builder.ToJson());
        //         });
        //         d.OwnsMany(p => p.Categories, cat =>
        //         {
        //             cat.ToJson();
        //             cat.OwnsMany(c => c.Labels);
        //             cat.OwnsMany(c => c.Options, opt =>
        //             {
        //                 opt.Ignore(o => o.RelatedProduct);
        //                 opt.Ignore(o => o.Image);
        //             });
        //             
        //             cat.Ignore(c => c.Validations);
        //             cat.Ignore(c => c.CustomizationTemplate);
        //         });
        //         d.OwnsMany(p => p.Fields);
        //         d.OwnsMany(p => p.Relationships, rel =>
        //         {
        //             rel.ToJson();
        //             rel.OwnsMany(r => r.RelatedProducts);
        //         });
        //         d.OwnsMany(p => p.CategoryRibbons);
        //         d.OwnsMany(p => p.ProductRibbons);
        //         d.OwnsMany(p => p.ShowAndHides);
        //         d.Ignore(c => c.Metadata);
        //         d.Ignore(c => c.Media);
        //         d.Ignore(c => c.Pricing);
        //         d.Ignore(c => c.ProductionInfo);
        //     });
        
       
    }
}