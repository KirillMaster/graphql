namespace ProductsMicroservice.FullRelational
{
    public class Image
    {
        public string Url { get; set; } = null!;
    }

    public class BoxSize : IdName
    {
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CartName { get; set; } = null!;
        public string EnglishName { get; set; } = null!;
        public string EnglishCartName { get; set; } = null!;
        public int Order { get; set; }
        public bool IsRequired { get; set; }
        public bool IsActive { get; set; }
        public string? DisplayType { get; set; }
        public string Type { get; set; } = null!;
        public List<Label> Labels { get; set; } = new();
        public List<Option>? Options { get; set; }
        public int? TextMinLength { get; set; }
        public bool TextIsMultiline { get; set; }
        public int? TextMaxLength { get; set; }
        public string? TextPlaceholder { get; set; }
        public int? TooltipId { get; set; }
        public int? GlossaryId { get; set; }
        public Image? CustomizationTemplate { get; set; }
        public string Uid { get; set; } = null!;
        public Dictionary<string, Validation> Validations { get; set; } = new();
    }

    public class CdnImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Path { get; set; } = null!;
    }

    public class CdnImageDimensions
    {
        public int Id { get; set; }
        public CdnImage Original { get; set; } = null!;
        public CdnImage Medium { get; set; } = null!;
    }

    public class Currency
    {
        public string Code { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string Side { get; set; } = null!;
    }

    public class DigitalAsset : ProductPrimaryKey
    {
        //extensions
        public ProductMedia Media { get; set; }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Alt { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public CdnImageDimensions? CdnImages { get; set; }
        public WistiaVideo? WistiaVideo { get; set; }
        public WistiaVideo? ThreeSixtyWistiaVideo { get; set; }
    }

    public class Family : IdName
    {
    }

    public class Field
    {
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
        public int Order { get; set; }
    }

    public class IdName
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class ProductPricing
    {
        public string PriceElements { get; set; } = null!;
        public decimal SellingPrice { get; set; }
        public decimal? CrossedPrice { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? SupplierPrice { get; set; }
    }

    public class ProductSizeHsCode : IdName
    {
    }

    public class RelatedProductPricing
    {
        public decimal Price { get; set; }
        public string PricingType { get; set; } = null!;
    }

    public class Label : IdName
    {
    }

    public class Metadata
    {
        public string SchemaVersion { get; set; } = null!;
    }

    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CartName { get; set; } = null!;
        public string EnglishName { get; set; } = null!;
        public string EnglishCartName { get; set; } = null!;
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public bool IsPlaceholder { get; set; }
        public int Order { get; set; }
        public decimal PriceAdjustment { get; set; }
        public bool UsePriceAdjustmentInName { get; set; }
        public Image? Image { get; set; }
        public SwitchProduct? RelatedProduct { get; set; }
        public string CartDisplayType { get; set; } = null!;
    }

    public class Product : ProductId
    {
        //extended fields
        public string CurrencyCode { get; set; }
        
        public string Type { get; set; } = null!;
        public long VersionId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset OnlineDate { get; set; }
        public Family Family { get; set; } = null!;
        public ProductionInfo? ProductionInfo { get; set; }
        public string? Url { get; set; }
        public string Name { get; set; } = null!;
        // public List<Category> Categories { get; set; } = new();
        // public List<ShowAndHide> ShowAndHides { get; set; } = new();
        // public List<Field> Fields { get; set; } = new();
        // public List<Relationship> Relationships { get; set; } = new();
        // public Site Site { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Instruction { get; set; } = null!;
        public bool IsOutOfStock { get; set; }
        public bool IsActive { get; set; }
        // public ProductPricing Pricing { get; set; } = null!;
        // public Metadata Metadata { get; set; } = null!;
        // public Dictionary<string, string> Translations { get; set; } = new();
        public bool IsArchived { get; set; }
        public bool IsDiamond { get; set; } 
        public ProductMedia Media { get; set; } = null!;
        //added nullable string
        public string? UpperDescription { get; set; } = null!;
        public List<Ribbon> ProductRibbons { get; set; } = new(); 
      // public List<Ribbon> CategoryRibbons { get; set; } = new();
        public bool? UseFriendlyUrl { get; set; } = null!;
        public string? FriendlyUrl { get; set; } = null!;
        public bool? NoIndex { get; set; } = null!;
        public string[]? ExcludedCountries { get; set; } = null;
    }

    public class ProductId
    {
        public int Id { get; set; }
        public int ShortId { get; set; }
        public string Sku { get; set; } = null!;
    }

    public class ProductionInfo
    {
        public bool IsNonEnglishInscription { get; set; }
        public BoxSize? BoxSize { get; set; }
        public decimal Weight { get; set; }
        public ProductSizeHsCode? ProductSizeHsCode { get; set; }
        public string? ProductSize { get; set; }
        public string SupplierProductId { get; set; } = null!;
        public int SupplierId { get; set; }
    }

    public class ProductMedia
    {
        public int? DefaultItemId { get; set; }
        public int? OverlayItemId { get; set; }
        public List<DigitalAsset> Items { get; set; } = new();
    }

    public class RelationshipProduct : ProductId
    {
        public List<string> RelatedCategoryUids { get; set; } = new();
        public List<string> RelatedChildCategoryUids { get; set; } = new();
        public long VersionId { get; set; }
        public bool? UseFriendlyUrl { get; set; } = null!;
        public string? FriendlyUrl { get; set; } = null!;
    }

    public class Ribbon : ProductPrimaryKey
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Value { get; set; } = null!;
    }

    public class ShowAndHide
    {
        public int ControllingCategory { get; set; }
        public string ControllingCategoryKey { get; set; } = null!;
        public int ControllingOption { get; set; }
        public List<int> ControlledCategories { get; set; } = new();
        public List<string> ControlledCategoryKeys { get; set; } = new();
    }

    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Currency Currency { get; set; } = null!;
        public Dictionary<string, string> Translations { get; set; } = new();
    }

    public class SwitchProduct
    {
        public int Id { get; set; }
        public int? ShortId { get; set; }
        public string Sku { get; set; } = null!;
        public RelatedProductPricing Pricing { get; set; } = null!;
        public string[]? ExcludedCountries { get; set; } = null!;
        public string? FriendlyUrl { get; set; } = null!;
    }

    public class Validation
    {
        public object Value { get; set; } = null!;
        public string ErrorText { get; set; } = null!;
    }

    public class WistiaVideo
    {
        public string Key { get; set; } = null!;
    }

    public class Relationship
    {
        public string Type { get; set; } = null!;
        public List<RelationshipProduct> RelatedProducts { get; set; } = new();
    }

    public class ProductPrimaryKey
    {
        public string CurrencyCode { get; set; }
        public long VersionId { get; set; }
        public string Sku { get; set; }
    }
}
