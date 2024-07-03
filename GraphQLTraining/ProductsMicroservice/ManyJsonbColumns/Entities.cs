using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductsMicroservice.ManyJsonbColumns;

[PrimaryKey(nameof(Sku), nameof(CurrencyCode), nameof(VersionId))]
[Table("catalog_product_sliced", Schema = "public")]
public class CatalogProduct
{
    public long Id { get; set; }
    public long VersionId { get; set; }
    public string Sku { get; set; }
    public string CurrencyCode { get; set; }
    public string Type { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime OnlineDate { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Instruction { get; set; }
    public bool IsOutOfStock { get; set; }
    public bool IsActive { get; set; }
    public bool IsArchived { get; set; }
    public bool IsDiamond { get; set; }
    public string? UpperDescription { get; set; }
    public bool UseFriendlyUrl { get; set; }
    public string FriendlyUrl { get; set; }
    public bool? NoIndex { get; set; }

    public Family Family { get; set; }
    public ProductionInfo ProductionInfo { get; set; }
    public List<Category> Categories { get; set; }
    [Column("show_and_hides")]
    public List<ShowAndHide> ShowAndHides { get; set; }
    public List<Field> Fields { get; set; }
    public List<Relationship> Relationships { get; set; }
    public Site Site { get; set; }
    public Pricing Pricing { get; set; }
    public Metadata Metadata { get; set; }
    public Media Media { get; set; }
    [Column("product_ribbons")]
    public List<Ribbon> ProductRibbons { get; set; }
    [Column("category_ribbons")]
    public List<Ribbon> CategoryRibbons { get; set; }
}

public class Family
{
    public long FamilyId { get; set; }
    public string Name { get; set; }
}

public class ProductionInfo
{
    public bool IsNonEnglishInscription { get; set; }
    public decimal Weight { get; set; }
    public string ProductSize { get; set; }
    public string SupplierProductId { get; set; }
    public long SupplierId { get; set; }
    public BoxSize BoxSize { get; set; }
    public ProductSizeHsCode ProductSizeHsCode { get; set; }
}

public class BoxSize
{
    public long BoxSizeId { get; set; }
    public string Name { get; set; }
}

public class ProductSizeHsCode
{
    public long ProductSizeHsCodeId { get; set; }
    public string Name { get; set; }
}

public class Category
{
    //public long CategoryId { get; set; }
    public string Name { get; set; }
    public string CartName { get; set; }
    public string EnglishName { get; set; }
    public string EnglishCartName { get; set; }
    public int Order { get; set; }
    public bool IsRequired { get; set; }
    public bool IsActive { get; set; }
    public string DisplayType { get; set; }
    public string Type { get; set; }
    public List<Label> Labels { get; set; }
    public List<Option> Options { get; set; }
}

public class Label
{
    //public long LabelId { get; set; }
    public string Name { get; set; }
}

public class Option
{
    //public long OptionId { get; set; }
    public string Name { get; set; }
    public string CartName { get; set; }
    public string EnglishName { get; set; }
    public string EnglishCartName { get; set; }
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; }
    public bool IsPlaceholder { get; set; }
    public int Order { get; set; }
    public decimal PriceAdjustment { get; set; }
    public bool UsePriceAdjustmentInName { get; set; }
    public string CartDisplayType { get; set; }
    public RelatedProduct? RelatedProduct { get; set; }
}

public class RelatedProduct
{
    public int RelationshipId { get; set; }
    public int Id { get; set; }
    public long RelatedProductId { get; set; }
    public long ShortId { get; set; }
    public string Sku { get; set; }
    public Pricing Pricing { get; set; }
}

public class ShowAndHide
{
    public string Type { get; set; }
}

public class Field
{
    public string Name { get; set; }
    public string Value { get; set; }
    public int Order { get; set; }
}

public class Relationship
{
    public string Type { get; set; }
}

public class Site
{
    public long SiteId { get; set; }
    public string Name { get; set; }
    public Currency Currency { get; set; }
}

public class Currency
{
    public string Code { get; set; }
    public string Symbol { get; set; }
    public string Side { get; set; }
}

public class Pricing
{
    public string PriceElements { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal CrossedPrice { get; set; }
    public decimal DiscountPercentage { get; set; }
    public decimal BasePrice { get; set; }
    public decimal SupplierPrice { get; set; }
}

public class Metadata
{
    public string SchemaVersion { get; set; }
}

public class Media
{
    public string? DefaultItemId { get; set; }
    public List<MediaItem> Items { get; set; }
}

public class MediaItem
{
   // public long MediaItemId { get; set; }
    public int Order { get; set; }
    public string Alt { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public string? Path { get; set; }
}

public class Ribbon
{
    public string Type { get; set; }
    public string Value { get; set; }
}