namespace ProductsMicroservice.FullRelational.CategoryManagerContract;

public class CategoryManagerContract
{
    public class Category
    {
        public Guid CategoryExternalId { get; set; }
        public Content Content { get; set; }
        public Seo Seo { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Facet> Facets { get; set; }
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
        public string Name { get; set; }
        public string UrlName { get; set; }
    }

    public class ProductInCategory
    {
        public string Sku { get; set; }
        public int BestSellersSortPosition { get; set; }
        public int OnlineDateSortPosition { get; set; }
        public ICollection<ProductFacet> ProductFacets  { get; set; }
    }

    public class ProductFacet
    {
        public string FieldName { get; set; }
        public string Value { get; set; }
    }

    public class Facet
    {
        public string Name { get; set; }
        public string FieldName { get; set; }
        public int Position { get; set; }
    }
}