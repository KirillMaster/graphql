using Microsoft.EntityFrameworkCore;
using ProductsMicroservice.FullRelational;
using ProductsMicroservice.ManyJsonbColumns;
using Category = ProductsMicroservice.FullRelational.Category;
using Label = ProductsMicroservice.FullRelational.Label;
using Ribbon = ProductsMicroservice.FullRelational.Ribbon;

//using ProductsMicroservice.ManyJsonbColumns;

namespace ProductsMicroservice;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
     public DbSet<Product> Products { get; set; }
     //public DbSet<CatalogProduct> ProductsSliced { get; set; }

    // public DbSet<ProductsMicroservice.ManyJsonbColumns.CatalogProduct> ProductsSliced { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        MapRelational(modelBuilder);
        //modelBuilder.ManyJsonbColumns();
    }

    private void MapRelational(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<Product>()
            .HasKey(p => new { p.Sku, p.VersionId, p.CurrencyCode });

        modelBuilder.Entity<Product>()
            .HasIndex(p => new { p.Sku, p.VersionId, p.CurrencyCode });
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Sku);

        modelBuilder.Entity<Product>()
            .OwnsOne(x => x.Family, family =>
        {
            family.ToJson();
        });
        
        modelBuilder.Entity<Product>().OwnsOne(e => e.ProductionInfo, productionInfo =>
         {
             productionInfo.ToJson();
             productionInfo.Property(pi => pi.IsNonEnglishInscription).IsRequired();
             productionInfo.Property(pi => pi.Weight).IsRequired();
             productionInfo.Property(pi => pi.ProductSize).IsRequired().HasMaxLength(50);
             productionInfo.Property(pi => pi.SupplierProductId).IsRequired().HasMaxLength(50);
             productionInfo.Property(pi => pi.SupplierId).IsRequired();

             productionInfo.OwnsOne(pi => pi.BoxSize, boxSize =>
             {
                 boxSize.Property(bs => bs.Id).IsRequired();
                 boxSize.Property(bs => bs.Name).IsRequired().HasMaxLength(50);
             });

             productionInfo.OwnsOne(pi => pi.ProductSizeHsCode, hsCode =>
             {
                 hsCode.Property(hs => hs.Id).IsRequired();
                 hsCode.Property(hs => hs.Name).IsRequired().HasMaxLength(50);
             });
         });
        
        modelBuilder.Entity<Product>()
            .HasMany(p => p.ProductRibbons)
            .WithOne()
            .HasForeignKey(c => new { c.Sku, c.VersionId, c.CurrencyCode });
        
        // modelBuilder.Entity<Product>()
        //     .HasMany(c => c.CategoryRibbons)
        //     .WithOne()
        //     .HasForeignKey(c => new { c.Sku, c.VersionId, c.CurrencyCode });

        modelBuilder.Entity<Ribbon>().HasIndex(x => new { x.Sku, x.VersionId, x.CurrencyCode });

        modelBuilder.Entity<Product>()
            .OwnsOne(p => p.Media, media =>
            {
                media.OwnsMany(x => x.Items, item =>
                {
                    item.HasOne(c => c.Media)
                        .WithMany(c => c.Items)
                        .HasForeignKey(x => new { x.Sku, x.VersionId, x.CurrencyCode });

                    item.HasIndex(x => new { x.Sku, x.VersionId, x.CurrencyCode });

                    item.OwnsOne(c => c.CdnImages, cdnImages =>
                    {
                        cdnImages.OwnsOne(c => c.Medium);
                        cdnImages.OwnsOne(c => c.Original);
                    });

                    item.OwnsOne(c => c.WistiaVideo);
                    item.OwnsOne(c => c.ThreeSixtyWistiaVideo);
                });
            });
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Categories)
            .WithOne()
            .HasForeignKey(x => new { x.Sku, x.VersionId, x.CurrencyCode });
        modelBuilder.Entity<Category>()
            .HasIndex(x => new { x.Sku, x.VersionId, x.CurrencyCode });

        modelBuilder.Entity<Category>()
            .HasKey(x => x.Uid);
        
        modelBuilder.Entity<Category>()
            .HasIndex(x => x.Uid);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Options)
            .WithOne()
            .HasForeignKey(x => x.CategoryUid);

        modelBuilder.Entity<Category>()
            .OwnsOne(c => c.CustomizationTemplate);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Labels)
            .WithOne()
            .HasForeignKey(x => x.CategoryUid);

        modelBuilder.Entity<Label>()
            .HasIndex(x => x.CategoryUid);

        modelBuilder.Entity<Label>()
            .HasKey(x => new { x.Id, x.CategoryUid });

        modelBuilder.Entity<ProductsMicroservice.FullRelational.Option>()
            .HasKey(x => new { x.Id, x.CategoryUid });

        modelBuilder.Entity<ProductsMicroservice.FullRelational.Option>()
            .HasIndex(x => x.CategoryUid);

        modelBuilder.Entity<ProductsMicroservice.FullRelational.Option>()
            .OwnsOne(c => c.Image);
        modelBuilder.Entity<ProductsMicroservice.FullRelational.Option>()
            .OwnsOne(c => c.RelatedProduct, relatedProduct =>
            {
                relatedProduct.OwnsOne(c => c.Pricing);
            });

    }
}