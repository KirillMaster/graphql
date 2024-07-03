using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ProductsMicroservice.OneJsonbColumn;

namespace ProductsMicroservice.OneJsonbColumn;

[PrimaryKey(nameof(SKU), nameof(CurrencyCode), nameof(CatalogVersionId))]
[Table("catalogproduct", Schema = "public")]
public class CatalogProduct
{
    public string SKU { get; set; }
    public int ShortId { get; set; }
    public string CurrencyCode { get; set; }
    [Column("createdat")]
    public DateTimeOffset CreatedAt { get; set; }
    [Column("datajson")]
    public LocalProduct Product { get; set; }
    public long CatalogVersionId { get; set; }
    public string FriendlyUrl { get; set; }

}
