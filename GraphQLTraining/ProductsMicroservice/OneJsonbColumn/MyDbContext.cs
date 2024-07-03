using Microsoft.EntityFrameworkCore;
using ProductsMicroservice.FullRelational;
using ProductsMicroservice.ManyJsonbColumns;
using Category = ProductsMicroservice.FullRelational.Category;
using Field = ProductsMicroservice.FullRelational.Field;
using Label = ProductsMicroservice.FullRelational.Label;
using Relationship = ProductsMicroservice.FullRelational.Relationship;
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
     public DbSet<Product> Products { get; set; }
     public DbSet<Category> Categories { get; set; }
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
        modelBuilder.Entity<ProductCategory>()
            .HasIndex(x => new { x.Sku, x.VersionId, x.CurrencyCode });

        modelBuilder.Entity<ProductCategory>()
            .HasKey(x => x.Uid);
        
        modelBuilder.Entity<ProductCategory>()
            .HasIndex(x => x.Uid);

        modelBuilder.Entity<ProductCategory>()
            .HasMany(c => c.Options)
            .WithOne()
            .HasForeignKey(x => x.CategoryUid);

        modelBuilder.Entity<ProductCategory>()
            .OwnsOne(c => c.CustomizationTemplate);

        modelBuilder.Entity<ProductCategory>()
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
            .HasForeignKey(x => new { x.Sku, x.VersionId, x.CurrencyCode });

        modelBuilder.Entity<ShowAndHide>()
            .HasKey(x => new { x.Id });
        modelBuilder.Entity<ShowAndHide>()
            .HasIndex(x => new { x.Sku, x.VersionId, x.CurrencyCode });
        
        modelBuilder.Entity<Product>()
            .HasMany(c => c.Fields)
            .WithOne()
            .HasForeignKey(x => new { x.Sku, x.VersionId, x.CurrencyCode });
        
        modelBuilder.Entity<ProductsInCategories>()
            .HasKey(pic => new { pic.CategoryId, pic.Sku, pic.VersionId, pic.CurrencyCode });
        
        modelBuilder.Entity<ProductsInCategories>()
            .HasOne(pic => pic.Product)
            .WithMany(p => p.ProductsInCategories)
            .HasForeignKey(pic => new { pic.Sku, pic.VersionId, pic.CurrencyCode });
        
        modelBuilder.Entity<ProductsInCategories>()
            .HasOne(pic => pic.CategoryProduct)
            .WithMany(c => c.ProductsInCategories)
            .HasForeignKey(pic => new {pic.Sku, pic.CategoryId});


        modelBuilder.Entity<Product>().HasIndex(x => x.Sku);

        modelBuilder.Entity<Field>()
            .HasKey(x => new { x.Id });
        modelBuilder.Entity<Field>()
            .HasIndex(x => new { x.Sku, x.VersionId, x.CurrencyCode });

        modelBuilder.Entity<Product>()
            .HasMany(x => x.Relationships)
            .WithOne()
            .HasForeignKey(x => new { x.Sku, x.VersionId, x.CurrencyCode });
        modelBuilder.Entity<Relationship>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Relationship>()
            .HasIndex(x => new { x.Sku, x.VersionId, x.CurrencyCode });

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
        
        //categories
        modelBuilder.Entity<Category>()
            .HasMany(x => x.Facets)
            .WithOne()
            .HasForeignKey(x => x.CategoryId);
        

        modelBuilder.Entity<Category>()
            .OwnsOne(category => category.Seo, seo =>
            {
                seo.OwnsMany(x => x.SeoCategories, seoCategory =>
                {
                    seoCategory.HasOne(x => x.Seo)
                        .WithMany(x => x.SeoCategories)
                        .HasForeignKey(x => x.CategoryId);
                    seoCategory.HasIndex(x => x.CategoryId);
                });
            });

        modelBuilder.Entity<Category>()
            .OwnsOne(x => x.Content);

        modelBuilder.Entity<Facet>()
            .HasIndex(x => x.CategoryId);
        
        modelBuilder.Entity<Facet>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Category>()
            .HasKey(x => x.CategoryExternalId);

        modelBuilder.Entity<Category>()
            .HasMany(x => x.ProductsInCategory)
            .WithOne()
            .HasForeignKey(x => x.CategoryId);

        modelBuilder.Entity<CategoryProduct>()
            .HasIndex(x => x.CategoryId);

        modelBuilder.Entity<CategoryProduct>()
            .HasKey(x => new { x.ProductSku, x.CategoryId });

        modelBuilder.Entity<CategoryProduct>()
            .HasMany(x => x.ProductFacets)
            .WithOne()
            .HasForeignKey(x => new { x.Sku, x.CategoryId });
        

        modelBuilder.Entity<ProductFacet>()
            .HasIndex(x => new { x.Sku, x.CategoryId });
        
        modelBuilder.Entity<ProductFacet>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<ProductFacet>()
            .HasIndex(x => x.FieldName);

        modelBuilder.Entity<Facet>()
            .HasIndex(x => x.FieldName);
    }
}