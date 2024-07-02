using Microsoft.EntityFrameworkCore;

namespace ProductsMicroservice.ManyJsonbColumns;

public static class ModelBuilderExtensions
{
    public static void ManyJsonbColumns(this ModelBuilder builder)
{
    builder.Entity<ProductsMicroservice.ManyJsonbColumns.CatalogProduct>(entity =>
    {
        entity.Property(e => e.Id).IsRequired();
        entity.Property(e => e.Sku).IsRequired().HasMaxLength(50);
        entity.Property(e => e.CurrencyCode).IsRequired().HasMaxLength(3).HasColumnName("currency_code");
        entity.Property(e => e.Type).IsRequired().HasMaxLength(50).HasColumnName("type");
        entity.Property(e => e.UpdatedAt).IsRequired().HasColumnName("updated_at");
        entity.Property(e => e.OnlineDate).IsRequired().HasColumnName("online_date");
        entity.Property(e => e.Url).HasMaxLength(255).HasColumnName("url");
        entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("name");
        entity.Property(e => e.Description).HasColumnType("text");
        entity.Property(e => e.Instruction).HasColumnType("text");
        entity.Property(e => e.IsOutOfStock).IsRequired().HasColumnName("is_out_of_stock");
        entity.Property(e => e.IsActive).IsRequired().HasColumnName("is_active");
        entity.Property(e => e.IsArchived).IsRequired().HasColumnName("is_archived");
        entity.Property(e => e.IsDiamond).IsRequired().HasColumnName("is_diamond");
        entity.Property(e => e.UpperDescription).HasColumnType("text").HasColumnName("upper_description");
        entity.Property(e => e.UseFriendlyUrl).IsRequired().HasColumnName("use_friendly_url");
        entity.Property(e => e.FriendlyUrl).HasMaxLength(255).HasColumnName("friendly_url");
        entity.Property(e => e.NoIndex).IsRequired().HasColumnName("no_index");
        entity.Property(e => e.VersionId).IsRequired().HasColumnName("version_id");

        entity.OwnsOne(e => e.Family, family =>
        {
            family.ToJson();
            family.Property(f => f.FamilyId).IsRequired();
            family.Property(f => f.Name).IsRequired().HasMaxLength(100);
        });

        entity.OwnsOne(e => e.ProductionInfo, productionInfo =>
        {
            productionInfo.ToJson();
            productionInfo.Property(pi => pi.IsNonEnglishInscription).IsRequired();
            productionInfo.Property(pi => pi.Weight).IsRequired();
            productionInfo.Property(pi => pi.ProductSize).IsRequired().HasMaxLength(50);
            productionInfo.Property(pi => pi.SupplierProductId).IsRequired().HasMaxLength(50);
            productionInfo.Property(pi => pi.SupplierId).IsRequired();

            productionInfo.OwnsOne(pi => pi.BoxSize, boxSize =>
            {
                boxSize.Property(bs => bs.BoxSizeId).IsRequired();
                boxSize.Property(bs => bs.Name).IsRequired().HasMaxLength(50);
            });

            productionInfo.OwnsOne(pi => pi.ProductSizeHsCode, hsCode =>
            {
                hsCode.Property(hs => hs.ProductSizeHsCodeId).IsRequired();
                hsCode.Property(hs => hs.Name).IsRequired().HasMaxLength(50);
            });
        });

        entity.OwnsMany(e => e.Categories, categories =>
        {
            categories.ToJson();

            categories.OwnsMany(c => c.Labels);

            categories.OwnsMany(c => c.Options, options =>
            {
                options.OwnsOne(o => o.RelatedProduct, relatedProduct =>
                {
                    relatedProduct.OwnsOne(rp => rp.Pricing);
                });
            });
        });

        entity.OwnsMany(e => e.ShowAndHides, showAndHides =>
        {
            showAndHides.ToJson();
            showAndHides.Property(sh => sh.Type).HasMaxLength(50);
        });

        entity.OwnsMany(e => e.Fields, fields =>
        {
            fields.ToJson();
            fields.Property(f => f.Name).HasMaxLength(255);
            fields.Property(f => f.Value).HasColumnType("text");
            fields.Property(f => f.Order).IsRequired();
        });

        entity.OwnsMany(e => e.Relationships, relationships =>
        {
            relationships.ToJson();
            relationships.Property(r => r.Type).HasMaxLength(50);
        });

        entity.OwnsOne(e => e.Site, site =>
        {
            site.ToJson();
            site.Property(s => s.SiteId).IsRequired();
            site.Property(s => s.Name).IsRequired().HasMaxLength(255);

            site.OwnsOne(s => s.Currency, currency =>
            {
                currency.Property(c => c.Code).IsRequired().HasMaxLength(3);
                currency.Property(c => c.Symbol).IsRequired().HasMaxLength(3);
                currency.Property(c => c.Side).IsRequired().HasMaxLength(10);
            });
        });

        entity.OwnsMany(e => e.ProductRibbons, ribbons =>
        {
            ribbons.ToJson();
            ribbons.Property(r => r.Type).HasMaxLength(50);
            ribbons.Property(r => r.Value).HasMaxLength(255);
        });

        entity.OwnsMany(e => e.CategoryRibbons, ribbons =>
        {
            ribbons.ToJson();
            ribbons.Property(r => r.Type).HasMaxLength(50);
            ribbons.Property(r => r.Value).HasMaxLength(255);
        });

        entity.OwnsOne(e => e.Pricing, pricing =>
        {
            pricing.ToJson();
            pricing.Property(p => p.PriceElements).IsRequired().HasMaxLength(50);
            pricing.Property(p => p.SellingPrice).IsRequired();
            pricing.Property(p => p.CrossedPrice).IsRequired();
            pricing.Property(p => p.DiscountPercentage).IsRequired();
            pricing.Property(p => p.BasePrice).IsRequired();
            pricing.Property(p => p.SupplierPrice).IsRequired();
        });

        entity.OwnsOne(e => e.Metadata, metadata =>
        {
            metadata.ToJson();
            metadata.Property(m => m.SchemaVersion).IsRequired().HasMaxLength(10);
        });

        entity.OwnsOne(e => e.Media, media =>
        {
            media.ToJson();
            media.OwnsMany(c => c.Items, items =>
            {
                //items.Property(i => i.MediaItemId).IsRequired();
                items.Property(i => i.Order).IsRequired();
                items.Property(i => i.Alt).HasMaxLength(255);
                items.Property(i => i.Title).HasMaxLength(255);
                items.Property(i => i.Type).HasMaxLength(50);
                items.Property(i => i.Path).HasMaxLength(255);
            });
        });
    });
}

}