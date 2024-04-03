using System.ComponentModel.DataAnnotations.Schema;
using Tenengroup.CatalogProxy.Domain.Catalog;

namespace ProductsMicroservice;

public class LocalProduct
{
    public string Type { get; set; }
    public string Sku { get; set; }
    
    public DateTimeOffset UpdatedAt { get; set; }

    public DateTimeOffset OnlineDate { get; set; }
    
    [Column("family")]
    public Family Family { get; set; }
}