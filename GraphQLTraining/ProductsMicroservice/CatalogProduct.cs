using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductsMicroservice;

[PrimaryKey(nameof(SKU), nameof(CurrencyCode), nameof(CatalogVersionId))]
[Table("catalogproduct", Schema = "public")]
public class CatalogProduct
{
    [Column("sku")]
    public string SKU { get; set; }
    [Column("shortid")]
    public int ShortId { get; set; }
    [Column("currencycode")]
    public string CurrencyCode { get; set; }
    [Column("createdat")]
    public DateTimeOffset CreatedAt { get; set; }
    [Column("catalogversionid")]
    public long CatalogVersionId { get; set; }
    [Column("friendlyurl")]
    public string FriendlyUrl { get; set; }
}