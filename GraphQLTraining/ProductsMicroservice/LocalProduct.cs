using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Tenengroup.CatalogProxy.Domain.Catalog;

namespace ProductsMicroservice;

public class LocalProduct
{
    public string Type { get; set; }
    public string Sku { get; set; }
    
    public DateTimeOffset UpdatedAt { get; set; }

    public DateTimeOffset OnlineDate { get; set; }
    
    // public List<Category> Categories { get; set; }
    public Family Family { get; set; }
    public Site Site { get; set; }
    public ProductMedia Media { get; set; }
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

    //public CdnImageDimensions? CdnImages { get; set; }
    
   // public WistiaVideo? WistiaVideo { get; set; }
    //
    // public WistiaVideo? ThreeSixtyWistiaVideo { get; set; }
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
    private string Key { get; set; }
}




// public class Translation {
//     public string Key { get; set; }
//     public string Value { get; set; }
// }