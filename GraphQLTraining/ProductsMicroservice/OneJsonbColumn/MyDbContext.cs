using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using ProductsMicroservice.FullRelational;
using ProductsMicroservice.ManyJsonbColumns;
using ProductsMicroservice.OneJsonbColumn;
using CatalogProduct = ProductsMicroservice.OneJsonbColumn.CatalogProduct;
using Category = ProductsMicroservice.FullRelational.Category;
using Field = ProductsMicroservice.FullRelational.Field;
using Label = ProductsMicroservice.FullRelational.Label;
using Relationship = ProductsMicroservice.FullRelational.Relationship;
using RelationshipProduct = ProductsMicroservice.FullRelational.RelationshipProduct;
using Ribbon = ProductsMicroservice.FullRelational.Ribbon;
using ShowAndHide = ProductsMicroservice.FullRelational.ShowAndHide;

//using ProductsMicroservice.ManyJsonbColumns;

namespace ProductsMicroservice;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
  //   public DbSet<Product> Products { get; set; }
     public DbSet<CatalogProduct> OneColumnProducts { get; set; }
     //public DbSet<CatalogProduct> ProductsSliced { get; set; }

    // public DbSet<ProductsMicroservice.ManyJsonbColumns.CatalogProduct> ProductsSliced { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
       // MapRelational(modelBuilder);
        //modelBuilder.ManyJsonbColumns();
        MapOneJsonbColumn(modelBuilder);
    }

    
    public class JsonbConverter<T> : ValueConverter<T, string>
    {
        public JsonbConverter() : base(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<T>(v))
        {
        }
    }
    
    private void MapOneJsonbColumn(ModelBuilder modelBuilder)
    {
        
        var converter = new JsonbConverter<LocalProduct>();
        modelBuilder.Entity<ProductsMicroservice.OneJsonbColumn.CatalogProduct>()
            .Property(p => p.Product)
            .HasConversion(converter)
            .HasColumnType("jsonb");
    }

    private void MapRelational(ModelBuilder modelBuilder)
    {
        
        
         modelBuilder.Entity<Product>()
            .HasKey(p => p.Uid);

        modelBuilder.Entity<Product>()
            .HasIndex(p => new { p.Sku, p.VersionId, p.CurrencyCode });
        modelBuilder.Entity<Product>()
            .HasIndex(x => x.Uid);
        
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Sku);

        modelBuilder.Entity<Product>()
            .OwnsOne(x => x.Family);
        
        modelBuilder.Entity<Product>().OwnsOne(e => e.ProductionInfo, productionInfo =>
         {
             productionInfo.OwnsOne(pi => pi.BoxSize);
             productionInfo.OwnsOne(pi => pi.ProductSizeHsCode);
         });
        
        // modelBuilder.Entity<Product>()
        //     .HasMany(p => p.ProductRibbons)
        //     .WithOne()
        //     .HasForeignKey(c => new { c.Sku, c.VersionId, c.CurrencyCode });
        
        // modelBuilder.Entity<Product>()
        //     .HasMany(c => c.CategoryRibbons)
        //     .WithOne()
        //     .HasForeignKey(c => new { c.Sku, c.VersionId, c.CurrencyCode });

        // modelBuilder.Entity<Ribbon>().HasIndex(x => new { x.Sku, x.VersionId, x.CurrencyCode });
        // modelBuilder.Entity<Ribbon>().HasKey(x => new { x.Id });

        modelBuilder.Entity<Product>()
            .OwnsOne(p => p.Media, media =>
            {
                media.OwnsMany(x => x.Items, item =>
                {
                    item.HasOne(c => c.Media)
                        .WithMany(c => c.Items)
                        .HasForeignKey(x => x.ProductUid);

                    item.HasIndex(x => x.ProductUid);

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
            .HasForeignKey(x => x.ProductUid);
        modelBuilder.Entity<Category>()
            .HasIndex(x => x.ProductUid);

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

        modelBuilder.Entity<Product>()
            .HasMany(c => c.ShowAndHides)
            .WithOne()
            .HasForeignKey(x => x.ProductUid);

        modelBuilder.Entity<ShowAndHide>()
            .HasKey(x => new { x.Id });
        modelBuilder.Entity<ShowAndHide>()
            .HasIndex(x => x.ProductUid);
        
        modelBuilder.Entity<Product>()
            .HasMany(c => c.Fields)
            .WithOne()
            .HasForeignKey(x => x.ProductUid);

        modelBuilder.Entity<Field>()
            .HasKey(x => new { x.Id });
        modelBuilder.Entity<Field>()
            .HasIndex(x => x.ProductUid);

        modelBuilder.Entity<Product>()
            .HasMany(x => x.Relationships)
            .WithOne()
            .HasForeignKey(x => x.ProductUid);
        modelBuilder.Entity<Relationship>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Relationship>()
            .HasIndex(x => x.ProductUid);

        modelBuilder.Entity<Relationship>()
            .HasMany(x => x.RelatedProducts)
            .WithOne()
            .HasForeignKey(x => x.RelationshipId);

        modelBuilder.Entity<RelationshipProduct>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<RelationshipProduct>()
            .HasIndex(x => x.RelationshipId);

        modelBuilder.Entity<Product>()
            .OwnsOne(c => c.Site, site =>
            {
                site.OwnsOne(c => c.Currency);
            });

        modelBuilder.Entity<Product>()
            .OwnsOne(c => c.Pricing);
        modelBuilder.Entity<Product>()
            .OwnsOne(c => c.Metadata);
    }
}