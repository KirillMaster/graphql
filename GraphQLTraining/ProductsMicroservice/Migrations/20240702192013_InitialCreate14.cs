using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    uid = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    cartname = table.Column<string>(type: "text", nullable: false),
                    englishname = table.Column<string>(type: "text", nullable: false),
                    englishcartname = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    isrequired = table.Column<bool>(type: "boolean", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    displaytype = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: false),
                    textminlength = table.Column<int>(type: "integer", nullable: true),
                    textismultiline = table.Column<bool>(type: "boolean", nullable: false),
                    textmaxlength = table.Column<int>(type: "integer", nullable: true),
                    textplaceholder = table.Column<string>(type: "text", nullable: true),
                    tooltipid = table.Column<int>(type: "integer", nullable: true),
                    glossaryid = table.Column<int>(type: "integer", nullable: true),
                    customizationtemplate_url = table.Column<string>(type: "text", nullable: true),
                    currencycode = table.Column<string>(type: "text", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.uid);
                    table.ForeignKey(
                        name: "fk_category_products_sku_versionid_currencycode",
                        columns: x => new { x.sku, x.versionid, x.currencycode },
                        principalTable: "products",
                        principalColumns: new[] { "sku", "versionid", "currencycode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "label",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryuid = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_label", x => x.id);
                    table.ForeignKey(
                        name: "fk_label_category_categoryuid",
                        column: x => x.categoryuid,
                        principalTable: "category",
                        principalColumn: "uid");
                });

            migrationBuilder.CreateTable(
                name: "option",
                columns: table => new
                {
                    categoryuid = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    cartname = table.Column<string>(type: "text", nullable: false),
                    englishname = table.Column<string>(type: "text", nullable: false),
                    englishcartname = table.Column<string>(type: "text", nullable: false),
                    isdefault = table.Column<bool>(type: "boolean", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    isplaceholder = table.Column<bool>(type: "boolean", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    priceadjustment = table.Column<decimal>(type: "numeric", nullable: false),
                    usepriceadjustmentinname = table.Column<bool>(type: "boolean", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    relatedproduct_id = table.Column<int>(type: "integer", nullable: true),
                    relatedproduct_shortid = table.Column<int>(type: "integer", nullable: true),
                    relatedproduct_sku = table.Column<string>(type: "text", nullable: true),
                    relatedproduct_pricing_price = table.Column<decimal>(type: "numeric", nullable: true),
                    relatedproduct_pricing_pricingtype = table.Column<string>(type: "text", nullable: true),
                    relatedproduct_excludedcountries = table.Column<string[]>(type: "text[]", nullable: true),
                    relatedproduct_friendlyurl = table.Column<string>(type: "text", nullable: true),
                    cartdisplaytype = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_option", x => new { x.id, x.categoryuid });
                    table.ForeignKey(
                        name: "fk_option_category_categoryuid",
                        column: x => x.categoryuid,
                        principalTable: "category",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_category_sku_versionid_currencycode",
                table: "category",
                columns: new[] { "sku", "versionid", "currencycode" });

            migrationBuilder.CreateIndex(
                name: "ix_category_uid",
                table: "category",
                column: "uid");

            migrationBuilder.CreateIndex(
                name: "ix_label_categoryuid",
                table: "label",
                column: "categoryuid");

            migrationBuilder.CreateIndex(
                name: "ix_option_categoryuid",
                table: "option",
                column: "categoryuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "label");

            migrationBuilder.DropTable(
                name: "option");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
