using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Tenengroup.CatalogProxy.Domain.Catalog;

namespace ProductsMicroservice;

public class LocalProduct
{
    public string Type { get; set; }
    public string Sku { get; set; }
    
    public DateTimeOffset UpdatedAt { get; set; }

    public DateTimeOffset OnlineDate { get; set; }
    
    public string Description { get; set; }

    public string Instruction { get; set; }

    public bool IsOutOfStock { get; set; }

    public bool IsActive { get; set; }
    
    public bool IsArchived { get; set; }

    public bool IsDiamond { get; set; }
    
    public string? UpperDescription { get; set; }
    
    public bool? UseFriendlyUrl { get; set; }

    public string? FriendlyUrl { get; set; }

    public bool? NoIndex { get; set; }
    
    public List<Relationship> Relationships { get; set; }
    
    public ProductionInfo ProductionInfo { get; set; }
    
    public List<Category> Categories { get; set; }
    public Family Family { get; set; }
    public Site Site { get; set; }
    public ProductMedia Media { get; set; }
    
    public ProductPricing Pricing { get; set; }
    
    public Metadata Metadata { get; set; }
    
    public List<Ribbon> ProductRibbons { get; set; } = new List<Ribbon>();

    public List<Ribbon> CategoryRibbons { get; set; } = new List<Ribbon>();
}

public class Site
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Currency Currency { get; set; }
    public string Translations { get; set; }
}

public class Currency
{
    public string Code { get; set; }
    public string Side { get; set; }
    public string Symbol { get; set; }
}

public class ProductMedia
{
    public int? DefaultItemId { get; set; }

    public int? OverlayItemId { get; set; }
    
    public List<Item> Items { get; set; }
}

public class Item
{
    public int Id { get; set; }
    
    public int Order { get; set; }

    public string Alt { get; set; }
    
    public string Title { get; set; }
    
    public string Type { get; set; }

    public CdnImageDimensions? CdnImages { get; set; }
    
    public WistiaVideo? WistiaVideo { get; set; }
    
    public WistiaVideo? ThreeSixtyWistiaVideo { get; set; }
}

public class CdnImageDimensions
{
    public CdnImage Original { get; set; }

    public CdnImage Medium { get; set; }
}

public class CdnImage
{
    public int Width { get; set; }

    public int Height { get; set; }

    public string Path { get; set; }
}

public class WistiaVideo
{
    public string Key { get; set; }
}

public class Relationship
{
    public string Type { get; set; }

    public List<RelationshipProduct> RelatedProducts { get; set; } = new List<RelationshipProduct>();
}

public class RelationshipProduct
{
    public List<string> RelatedCategoryUids { get; set; } = new List<string>();

    public List<string> RelatedChildCategoryUids { get; set; } = new List<string>();

    public long VersionId { get; set; }

    public bool? UseFriendlyUrl { get; set; }

    public string? FriendlyUrl { get; set; }
}

public class ProductionInfo
{
    public bool IsNonEnglishInscription { get; set; }

    public BoxSize? BoxSize { get; set; }

    public Decimal Weight { get; set; }

    public ProductSizeHsCode? ProductSizeHsCode { get; set; }

    public string? ProductSize { get; set; }

    public string SupplierProductId { get; set; }

    public int SupplierId { get; set; }
}

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string CartName { get; set; }

    public string EnglishName { get; set; }

    public string EnglishCartName { get; set; }

    public int Order { get; set; }

    public bool IsRequired { get; set; }

    public bool IsActive { get; set; }

    public string? DisplayType { get; set; }

    public string Type { get; set; }

    public List<Label> Labels { get; set; } = new List<Label>();

    public List<Option>? Options { get; set; }

    public int? TextMinLength { get; set; }

    public bool TextIsMultiline { get; set; }

    public int? TextMaxLength { get; set; }

    public string? TextPlaceholder { get; set; }

    public int? TooltipId { get; set; }

    public int? GlossaryId { get; set; }

    public Image? CustomizationTemplate { get; set; }

    public string Uid { get; set; }
    
    public List<ShowAndHide> ShowAndHides { get; set; } = new List<ShowAndHide>();
    
    public List<Field> Fields { get; set; } = new List<Field>();
    
  //ask Misha to strict types of this entity
  // public Dictionary<string, Validation> Validations { get; set; } = new Dictionary<string, Validation>();
}

public class Label
{
    [JsonPropertyName("Id")]
    public int Uid { get; set; }

    public string Name { get; set; }
}

public class Option
{
    [JsonPropertyName("Id")]
    public int Uid { get; set; }

    public string Name { get; set; }

    public string CartName { get; set; }

    public string EnglishName { get; set; }

    public string EnglishCartName { get; set; }

    public bool IsDefault { get; set; }

    public bool IsActive { get; set; }

    public bool IsPlaceholder { get; set; }

    public int Order { get; set; }

    public Decimal PriceAdjustment { get; set; }

    public bool UsePriceAdjustmentInName { get; set; }

    public Image? Image { get; set; }

    public SwitchProduct? RelatedProduct { get; set; }

    public string CartDisplayType { get; set; }
}


