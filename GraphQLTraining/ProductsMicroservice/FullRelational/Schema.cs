using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ProductsMicroservice.FullRelational
{
    public class Image
    {
        public string Url { get; set; } = null!;
    }

    public class BoxSize : IdName
    {
    }

    public class ProductCategory : ProductPrimaryKey
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
        //TODO::
       // public Dictionary<string, Validation> Validations { get; set; } = new();
    }

    public class CdnImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Path { get; set; } = null!;
    }

    public class CdnImageDimensions
    {
        public CdnImage? Original { get; set; } = null!;
        public CdnImage? Medium { get; set; } = null!;
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
        [Required]
        public CdnImageDimensions? CdnImages { get; set; }
        public WistiaVideo? WistiaVideo { get; set; }
        public WistiaVideo? ThreeSixtyWistiaVideo { get; set; }
    }

    public class Family : IdName
    {
    }

    public class Field : ProductPrimaryKey
    {
        public int Id { get; set; }
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
        public string CategoryUid { get; set; }
    }

    public class Metadata
    {
        public string SchemaVersion { get; set; } = null!;
    }

    public class Option
    {
        //navigation
        public string CategoryUid { get; set; }
        
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
        [Required]
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
        public List<ProductCategory> Categories { get; set; } = new();
        public List<ShowAndHide> ShowAndHides { get; set; } = new();
        public List<Field> Fields { get; set; } = new();
        public List<Relationship> Relationships { get; set; } = new();
        public Site Site { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Instruction { get; set; } = null!;
        public bool IsOutOfStock { get; set; }
        public bool IsActive { get; set; } 
        public ProductPricing Pricing { get; set; } = null!; 
        public Metadata Metadata { get; set; } = null!;
        // public Dictionary<string, string> Translations { get; set; } = new();
        public bool IsArchived { get; set; }
        public bool IsDiamond { get; set; } 
        public ProductMedia Media { get; set; } = null!;
        //added nullable string
        public string? UpperDescription { get; set; } = null!;
        
        //TODO:: refactor ribbons to have ProductRibbon type and CategoryRibbon type
        // public List<Ribbon> ProductRibbons { get; set; } = new();
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
        public int RelationshipId { get; set; }
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

    public class ShowAndHide : ProductPrimaryKey
    {
        //new key
        public int Id { get; set; }
        
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
        //TODO::
       // public Dictionary<string, string> Translations { get; set; } = new();
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

    public class Relationship : ProductPrimaryKey
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public List<RelationshipProduct> RelatedProducts { get; set; } = new();
    }

    public class ProductPrimaryKey
    {
        public string CurrencyCode { get; set; }
        public long VersionId { get; set; }
        public string Sku { get; set; }
    }
    
    
    //category manager contract
    public class Category
    {
        public Guid CategoryExternalId { get; set; }
        public Content Content { get; set; }
        public Seo Seo { get; set; }
        
    
        public List<CategoryProduct> ProductsInCategory { get; set; }
   
        public List<Facet> Facets { get; set; }
        
        public IEnumerable<FacetInfo> GetCategoryFacets(Guid categoryKey,  [Service] Repository repository, List<UserInputFilter> selectedFilters)
        {
            var facets = repository.GetFacets(categoryKey).ToList();
            var dbProductsInCategory = repository.GetCategories().Where(x => x.CategoryExternalId == categoryKey)
                .Include(x => x.ProductsInCategory)
                .ThenInclude(x => x.ProductFacets)
                .SelectMany(x => x.ProductsInCategory);

            var categoryFacets = facets.Select(x => x.FieldName);
            
            var mathcedProductsFacets = dbProductsInCategory.SelectMany(product => product.ProductFacets) 
                .Where(x => categoryFacets.Contains(x.FieldName))
                .ToList();

            var skus = mathcedProductsFacets.Select(x => new
                {
                    ProductFacet = x,
                    UserInputFilter = new UserInputFilter
                    {
                        FacetName = x.FieldName,
                        SelectedFilter = x.Value
                    },
                }).Where(x =>
                {
                    if (selectedFilters.Count == 0)
                    {
                        return true;
                    }
                    
                    return selectedFilters.Contains(x.UserInputFilter);
                })
                .Select(x => x.ProductFacet.Sku);

            return mathcedProductsFacets.Where(x => skus.Contains(x.Sku))
                .GroupBy(x => x.FieldName)
                .Select(x => new FacetInfo
                {
                    Position = facets.FirstOrDefault(f => f.FieldName == x.Key).Position,
                    FieldName = x.Key,
                    FilterAggregates = x.GroupBy(facet => facet.Value).Select(grouping => new FilterDto
                    {
                        Name = grouping.Key,
                        Count = grouping.Count()
                    }).OrderBy(x => x.Name).ToList()
                });
        }
    }
    
    //contract

    public class UserInputFilter : IEquatable<UserInputFilter>
    {
        public string FacetName { get; set; }
        public string SelectedFilter { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as UserInputFilter);
        }

        public bool Equals(UserInputFilter other)
        {
            if (other == null) return false;
            return string.Equals(FacetName, other.FacetName) && string.Equals(SelectedFilter, other.SelectedFilter);
        }

        public override int GetHashCode()
        {
            unchecked // Allow overflow, it's fine here
            {
                int hash = 17;
                hash = hash * 23 + (FacetName != null ? FacetName.GetHashCode() : 0);
                hash = hash * 23 + (SelectedFilter != null ? SelectedFilter.GetHashCode() : 0);
                return hash;
            }
        }

        public static bool operator ==(UserInputFilter left, UserInputFilter right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null))
            {
                return false;
            }

            if (ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(UserInputFilter left, UserInputFilter right)
        {
            return !(left == right);
        }
    }
    

    public class Content
    {
        public string BackofficeName { get; set; }
        public string Name { get; set; }
        public string UrlName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryImageLink { get; set; }
        public string ImageTitle { get; set; }
        public string ImageAlt { get; set; }
    }

    public class Seo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<SeoCategory> SeoCategories { get; set; }
        public string HeaderScript { get; set; }
        public string CategoryLowerSubtitle { get; set; }
    }

    public class SeoCategory
    {
        public Guid CategoryId { get; set; }
        public Seo Seo { get; set; }
        public string Name { get; set; }
        public string UrlName { get; set; }
    }

    public class CategoryProduct
    {
        public Guid CategoryId { get; set; }
        public string ProductSku { get; set; }
        public long ProductVersionId { get; set; }
        public string ProductCurrencyCode { get; set; }
        
        public Product Product { get; set; }
        public int BestSellersSortPosition { get; set; }
        public int OnlineDateSortPosition { get; set; }
        public ICollection<ProductFacet> ProductFacets  { get; set; }
        
    }

    public class ProductFacet
    {
        public Guid CategoryId { get; set; }
        public string Sku { get; set; }
        
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
    }

    public class Facet
    {
        public Guid CategoryId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string FieldName { get; set; }
        public int Position { get; set; }
    }
    
    public class CategoryDto {
        public Guid CategoryExternalId { get; set; }
        public Content Content { get; set; }
        public Seo Seo { get; set; }
        public List<FacetInfo> GetFacets(Guid categoryId, string selectedFilter = null)
        {
            //TODO:: добавить фильтрацию еще по фильтру
            var filter = "Denis Mom";

            var category = new List<Category>().FirstOrDefault(x => x.CategoryExternalId == categoryId);
         
            return category.Facets.SelectMany(categoryFacet =>
            {
                //берем все фасеты всех продуктов категории
                var aggregates = category.ProductsInCategory.SelectMany(product => product.ProductFacets) 
                    .Where(x => x.FieldName == categoryFacet.FieldName)
                    .Where(x =>
                    {
                        if (selectedFilter == null)
                        {
                            return true;
                        }

                        return selectedFilter == x.Value;
                    })
                    .GroupBy(x => x.FieldName)
                    //группируем по имени фасета
                    .Select(x => new FacetInfo
                    {
                        Position = categoryFacet.Position,
                        FieldName = categoryFacet.FieldName,
                        FilterAggregates = x.GroupBy(facet => facet.Value).Select(grouping => new FilterDto
                        {
                            Name = x.Key,
                            Count = x.Count()
                        }).Where(filter => filter.Count > 0).ToList()
                    });
                return aggregates;
            }).ToList();
        }
    }
    
    public class FilterDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class FacetInfo
    {
        public string FieldName { get; set; }
        public int Position { get; set; }
        public List<FilterDto> FilterAggregates { get; set; }
    }
}
